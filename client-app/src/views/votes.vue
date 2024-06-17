<template>
    <div>


<div class=" flex flex-col w-full gap-4 p-2">

    <div v-for="o in dump_data" class=" bg-slate-100 w-full  cursor-pointer hover:shadow-2xl flex justify-between items-center px-4 rounded-md drop-shadow-md min-h-16">

        <span>

            {{ o.name }} voted for {{ o.candted }} on {{ o.date }}
        </span>
  
       

    </div>

</div>
    </div>
</template>

<script setup lang="ts">

import {ref} from "vue";

// import {NButton} from "naive-ui"

const dump_data = ref([{

    name:"Bassam Elbadri",
    date:"25/05/2024 9:47 PM",
    candted:"John Dpe",


},
{
    name:"Mohammed Alrgieg",
    date:"25/05/2024 9:47 PM",
    candted:"John Dpe",

}

])

</script>

<style scoped>

</style>