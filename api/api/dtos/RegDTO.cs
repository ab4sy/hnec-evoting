namespace api.dtos
{
    public class RegDTO
    {



        public string FullName { get; set; } = null!;

        public string? NationalNo { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public string? PlaceOfBirth { get; set; }

        public string PhoneNo { get; set; } = null!;

        public string OTP { get; set; } = null!;

        public string Token { get; set; } = null!;

        public string? Email { get; set; }
        public short VotingCenterId { get; set; }

        public short? CityId { get; set; }

        public short? MunicipalityId { get; set; }

        public string? Address { get; set; }


    }


    public class Message
    {
        public string status { get; set; }
        public string message { get; set; }
    }

}
