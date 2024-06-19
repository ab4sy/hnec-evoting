<template>
  <div class="bg-blue-600">
    <div class="h-screen mx-auto container flex justify-center items-center">
      <div class="bg-white p-6 drop-shadow-lg w-5/6 h-5/6 overflow-y-auto rounded-lg flex justify-center items-center flex-col">
        <div class="flex flex-col gap-4 mb-4">
          <img class="w-80 mx-auto" src="@/assets/hnec.webp" alt="" srcset="" />
          <div class="font-bold text-3xl text-blue-500 text-center">Welocme to HNEC - E-Voting Kiosk</div>
        </div>
        <div v-if="stepCounter == 1" class="justify-center items-center flex-col gap-4 flex">
          <h1 class="font-semibold text-xl">Please scan QR code or enter card number below.</h1>
          <img class=" w-48 mx-auto" src="https://cdn.dribbble.com/users/1220941/screenshots/11463637/media/73d1a3758fd18a336cf36a3b1d5ffa1d.gif" alt="" srcset="" />
          
          <input class="p-2 border border-solid border-gray-400 rounded-lg text-center text-4xl" type="text" />
        </div>
        
        <div v-if="stepCounter == 2" class="justify-center items-center flex-col gap-4 flex">
          <img class=" w-48 mx-auto" src="https://gizmodo.com.au/wp-content/uploads/2015/02/25/fwz99dtzcdfvbmqmjhqc.gif?quality=75" alt="" srcset="" />
          <h1 class="font-bold text-3xl">Please enter your PIN Code</h1>

          <input class="p-2 border border-solid border-gray-400 rounded-lg text-center text-4xl" type="text" />
        </div>
        <div v-if="stepCounter == 3" class="justify-center items-center flex-col gap-4 flex">
          <div class="grid grid-cols-3 gap-4 w-full">
            <div @click="selectedDip = d.id" v-for="d in list" :key="d.id" class="  bg-slate-200 cursor-pointer rounded-lg p-2 drop-shadow-md" :class="selectedDip == d.id ? ' bg-blue-500' : ''">
              <div class="flex flex-col gap-4">

                <img class=" w-48 h-48  object-cover rounded-lg"  :src="d.img" alt="">
                <span>{{d.name}}</span>
                <span>{{d.description}}</span>
              </div>
            </div>
          </div>
        </div>
        <div v-if="stepCounter == 4" class="justify-center items-center flex-col gap-4 flex">
          <h1 class="font-bold text-3xl">are you sure you want to vote for Farhat Zargoun?</h1>
          <button class="bg-green-500 rounded-lg px-8 text-xl w-48 h-16 mt-4" @click="stepCounter++">Yes</button>
          <button class="bg-red-500 rounded-lg px-8 text-xl w-48 h-16 mt-4" @click="stepCounter--">No</button>
        </div>
        <div v-if="stepCounter == 5" class="justify-center items-center flex-col gap-4 flex">
          <img src="https://i.gifer.com/7efs.gif" alt="">
          <h1 class="font-bold text-3xl">Thank you</h1>
        </div>


        <button v-if="stepCounter<4" class=" bg-green-500 rounded-lg px-8 text-xl w-48 h-16 mt-4"   @click="stepCounter++">Next</button>


      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";

onMounted(()=>{
  list.value = list.value.sort(() => Math.random() - 0.5);

})
const stepCounter = ref(1 as number);
const selectedDip = ref(null as number | null);

const list = ref([
  {
    id : 1,
    img : 'https://media.istockphoto.com/id/1354026331/photo/portrait-of-confident-senior-businessman.jpg?s=1024x1024&w=is&k=20&c=nZORmwesPy3EP4wKUtw3YepRloR4sR-2rv9StsfVFnc=',
  name : 'Fathi Salem',
  description : 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Nesciunt, quaerat.'
  
},
  {
    id : 2,
    img:'https://media.istockphoto.com/id/1795100877/photo/mid-aged-businessman-wearing-suit-and-tie-against-isolated-background.jpg?s=1024x1024&w=is&k=20&c=VNSyPzPZ6z-cr4nqa9JVTzMxrRhQAdpQZzFNiDbj6rg=',
  name : 'Ahmed Khalid',
  description : 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Nesciunt, quaerat.'
  
},
  {
    id : 3,
    img: 'https://media.istockphoto.com/id/1219980089/photo/confident-businessman-posing.jpg?s=1024x1024&w=is&k=20&c=tT3Mkd60s7BadKwmD1EOpBvxdyyfN7ydR4NbBDgria8=',
  name : 'Farhat Zargoun',
  description : 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Nesciunt, quaerat.'
  
},
])
</script>

<style scoped></style>
