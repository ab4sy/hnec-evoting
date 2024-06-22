<template>
    <div>


<div class=" flex flex-col w-full gap-4 p-2">

    <div v-for="o in votes" class=" bg-slate-100 w-full  cursor-pointer hover:shadow-2xl flex justify-between items-center px-4 rounded-md drop-shadow-md min-h-16">

        <span>

            {{ list.find(x=> x.id == o.candidateId)?.name }} Has {{ o.count }} votes
        </span>
  
       

    </div>

</div>
    </div>
</template>

<script setup lang="ts">

import api from "@/api/api-client";
import { AxiosResponse } from "axios";
import {ref, onBeforeMount} from "vue";

onBeforeMount(async () => {
  await load();
});

const votes = ref([] as any[]);

const load = async () => {
  await api
    .get(`/votes`)
    .then(async (response: AxiosResponse) => {
        votes.value = response.data.result;
      console.log(response);
    })
    .catch((error: any) => {
      console.log(error);
      // handle error
      // message.error(error.response.data);
    });
};


const list = ref([
  {
    id: 1,
    img: "https://media.istockphoto.com/id/1354026331/photo/portrait-of-confident-senior-businessman.jpg?s=1024x1024&w=is&k=20&c=nZORmwesPy3EP4wKUtw3YepRloR4sR-2rv9StsfVFnc=",
    name: "Fathi Salem",
    description: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nesciunt, quaerat.",
  },
  {
    id: 2,
    img: "https://media.istockphoto.com/id/1795100877/photo/mid-aged-businessman-wearing-suit-and-tie-against-isolated-background.jpg?s=1024x1024&w=is&k=20&c=VNSyPzPZ6z-cr4nqa9JVTzMxrRhQAdpQZzFNiDbj6rg=",
    name: "Ahmed Khalid",
    description: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nesciunt, quaerat.",
  },
  {
    id: 3,
    img: "https://media.istockphoto.com/id/1219980089/photo/confident-businessman-posing.jpg?s=1024x1024&w=is&k=20&c=tT3Mkd60s7BadKwmD1EOpBvxdyyfN7ydR4NbBDgria8=",
    name: "Farhat Zargoun",
    description: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Nesciunt, quaerat.",
  },
]);

</script>

<style scoped>

</style>