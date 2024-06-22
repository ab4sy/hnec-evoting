using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using models;
using api.dtos;
using System.Threading.Tasks.Dataflow;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<HnecEvotingContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("db"));
});



// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(builder => builder
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);

app.UseHttpsRedirection();

app.UseDeveloperExceptionPage();




app.MapPost("api/otp", async (string PhoneNo, HnecEvotingContext _db) =>
{




    var otp = new Random().Next(1111, 9999).ToString();



    var data = new Dictionary<string, string> {

              {"recipient", $"218{PhoneNo[1..]}" },
              {"sender_id", "17320"},
              {"type", "unicode"},
              {"message",otp }

                };


    var _httpClient = new HttpClient();

    _httpClient.BaseAddress = new Uri("https://isend.com.ly/api/v3/");
    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "51|R3Oh6tT4jLwcwaqGbqyn36Gn13uIH7NOepqhlGFp");


    var payload = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

    var response = await _httpClient.PostAsync("sms/send", payload);



    var content = await response.Content.ReadFromJsonAsync<Message>();


    var hashed = BCrypt.Net.BCrypt.EnhancedHashPassword(otp);





    return Results.Ok( new
    {
        token = hashed,
    });
});

app.MapPost("api/register", async (RegDTO DTO, HnecEvotingContext _db) =>
{

    if (!BCrypt.Net.BCrypt.EnhancedVerify(DTO.OTP, DTO.Token)) return Results.BadRequest(new { message = "Invalid verification code" });


    var existingVoter = await _db.Voters.Where(v => v.PhoneNo == DTO.PhoneNo || v.NationalNo == DTO.NationalNo).AnyAsync();

    if (existingVoter) return Results.BadRequest(new { message = "Phone no. already exists" });

    var voter = new Voter
    {
        FullName = DTO.FullName,
        CardNo = new Random().Next(111111, 999999).ToString(),
        CardExpDate = DateOnly.FromDateTime(DateTime.Now.AddYears(4)),
        NationalNo = DTO.NationalNo,
        DateOfBirth = DTO.DateOfBirth,
        PhoneNo = DTO.PhoneNo,
        Email = DTO.Email,
        CardPin= "1111",
        VotingCenterId = DTO.VotingCenterId,
        CityId = DTO.CityId,
        MunicipalityId = DTO.MunicipalityId,
        Address = DTO.Address,
        Status = 10
    };

    await _db.Voters.AddAsync(voter);
    _db.SaveChanges();



    return Results.Ok(new { message = "ok!" });
});


app.MapPost("api/change-status", async (int id, short status, HnecEvotingContext _db) =>
{

    var card = await _db.Voters.Where(w => w.Id == id).FirstOrDefaultAsync();

    if (card == null) return Results.NotFound(new
    {
        message = "no card was found!"
    });

    card.Status = status;


    await _db.SaveChangesAsync();

    return Results.Ok(new { message = "ok!" });
});

app.MapGet("api/reqs", async (HnecEvotingContext _db) =>
{

    var reqs = await _db.Voters.Where(w => w.Status != 9).Select(s => new
    {
        s.FullName,
        s.NationalNo,
        s.VotingCenterId,
        s.Status,
        s.PlaceOfBirth,
        s.DateOfBirth,
        s.Address,
        s.PhoneNo,
        s.Id,
        s.CardNo,
        s.CardExpDate,
        s.CardPin,
    }).ToListAsync();

    return Results.Ok(new { result = reqs });
});


app.MapPost("api/vote", async (VoteDTO DTO ,  HnecEvotingContext _db) =>
{


    var voterId = await _db.Voters.Where(w => w.CardNo == DTO.CardNo && w.CardPin == DTO.PIN).Select(s=> s.Id).FirstOrDefaultAsync();

    if (voterId == 0) return Results.NotFound(new { message = "PIN not vaild" });

    var vote = new Vote
    {
        CandidateId = DTO.CandidateId,
        VoterId = voterId,
        VotingDate = DateOnly.FromDateTime(DateTime.Now),
    };

    await _db.Votes.AddAsync(vote);
    _db.SaveChanges();



    return Results.Ok(new { result = "reqs" });
});


app.MapGet("api/votes", async ( HnecEvotingContext _db) =>
{

    var votes = await _db.Votes.Where(w => w.Status != 9)
    .GroupBy(g=> g.CandidateId)
    .Select(s => new
    {
        candidateId =  s.Key,
       count = s.Count()

    }).ToListAsync();

    return Results.Ok(new { result = votes });


});


app.Run();