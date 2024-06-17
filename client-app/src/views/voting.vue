<template>
  <div class="bg-blue-600">
    <div class="h-screen mx-auto container flex justify-center items-center">
      <div class="bg-white p-6 rounded-sm drop-shadow-lg w-5/6 h-5/6 overflow-y-auto">
        <div v-if="stepCounter == 1" class="justify-center items-center flex-col gap-4 flex">
          <h1 class="font-bold text-3xl">Please sacn qr code ir insert card number below</h1>

          <input class="p-2 border border-solid border-gray-400 rounded-lg text-center text-4xl" type="text" />
        </div>

        <div v-if="stepCounter == 2" class="justify-center items-center flex-col gap-4 flex">
          <h1 class="font-bold text-3xl">Please insert otp recived on your phone</h1>

          <input class="p-2 border border-solid border-gray-400 rounded-lg text-center text-4xl" type="text" />
        </div>
        <div v-if="stepCounter == 3" class="justify-center items-center flex-col gap-4 flex">
          <div class="grid grid-cols-3 gap-4 w-full">
            <div @click="selectedDip = d" v-for="d in 3" class="h-64 bg-red-400 cursor-pointer" :class="selectedDip == d ? 'bg-green-600' : ''">
              <div class="flex flex-col gap-4">
                <span>Name</span>
                <span>description</span>
                <span>{{ d }}</span>
              </div>
            </div>
          </div>
        </div>
        <div v-if="stepCounter == 4" class="justify-center items-center flex-col gap-4 flex">
          <h1 class="font-bold text-3xl">are you sure you want to vote for name here?</h1>
          <button @click="stepCounter++">yes</button>
          <button @click="stepCounter--">no</button>
        </div>
        <div v-if="stepCounter == 5" class="justify-center items-center flex-col gap-4 flex">
          <h1 class="font-bold text-3xl">Thank you</h1>

        </div>

        <button @click="stepCounter++">Next</button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
const stepCounter = ref(1 as number);
const selectedDip = ref(null as number | null);
</script>

<style scoped></style>
