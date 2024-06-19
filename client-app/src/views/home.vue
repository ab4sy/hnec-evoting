<template>
  <div>
    
    <img class="w-80 mx-auto mb-8" src="@/assets/hnec.webp" alt="" srcset="" />

    <div>
      <div class="flex justify-between font-bold">
        <div  v-for="m in menu" @click="active_tab=m.tab" :class=" active_tab==m.tab ? ' underline' : ''" class="text-center w-full">
          <span>{{m.name}}</span>
        </div>

      </div>

      <div>
        <reqs v-if="active_tab==1"/>
        <votes v-if="active_tab==2"/>
        
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import {ref} from "vue"

import reqs from "./reqs.vue"
import votes from "./votes.vue"

const active_tab = ref(1 as number);
const menu = ref([{
  name:'Card Reqs',
  tab:1
},
{
  name:'Votes',
  tab:2
},
]);

</script>

<style scoped></style>
