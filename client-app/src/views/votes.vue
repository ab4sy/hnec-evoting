<template>
    <div>


<div class=" flex flex-col w-full gap-4 p-2">

    <div v-for="o in dump_data" class=" bg-slate-100 w-full  cursor-pointer hover:shadow-2xl flex justify-between items-center px-4 rounded-md drop-shadow-md min-h-16">

        <span>

            {{ o.name }} Has {{ o.votes }} votes
        </span>
  
       

    </div>

</div>
    </div>
</template>

<script setup lang="ts">

import {ref} from "vue";

// import {NButton} from "naive-ui"

const dump_data = ref([
    {

    name:"Ahmed Khalid",
    votes:"2,356",


},
    {

    name:"Fathi Salem",
    votes:"20,788",


},
    {

    name:"Farhat Zargoun",
    votes:"40,953",


},


])

</script>

<style scoped>

</style>