<template>
  <div>
    <div class="flex flex-col w-full gap-4 p-2">
      <div v-for="o in dump_data" class="bg-slate-100 w-full cursor-pointer hover:shadow-2xl flex justify-between items-center px-4 rounded-md drop-shadow-md min-h-16">
        <span>
          {{ o.name }}
        </span>
        <span>
          {{ o.date }}
        </span>
        

        <div class="flex gap-4">
          <n-button type="primary" class=""> View </n-button>
          <n-button type="error" class=""> Cancel </n-button>
          <n-button type="warning" class=""> ِAccept / Print </n-button>
        </div>
      </div>
    </div>

    <n-modal v-model:show="show_modal">
      <div class="bg-white h-60 p-4">
        <div class="flex justify-between border-b-4 border-blue-400">
          <img class="w-48" src="@/assets/hnec.webp" alt="" srcset="" />
          <span class="font-semibold text-3xl">بطاقة ناخب</span>
        </div>

        <div class="flex gap-4 p-4 justify-between">
          <div>
            <QRCodeVue3
              :dots-options="{
                type: 'square',
                color: '#000000',
              }"
              :cornersSquareOptions="{ type: 'square', color: '#000000' }"
              :width="100"
              :height="100"
              value="123456"
            />
          </div>

          <div class="font-semibold text-xl text-right gap-4">
            <div>الاسم : بسام سراج الدين البدري</div>
            <div>رقم البطاقة : 123456789123</div>
            <div>الرقم الوطني : 1200000657889</div>
          </div>
        </div>
      </div>
    </n-modal>


  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import QRCodeVue3 from "qrcode-vue3";

import { NButton, NModal } from "naive-ui";

const show_modal = ref(true as boolean);

const dump_data = ref([
  {
    name: "Bassam Elbadri",
    date: "25/05/2024 9:47 PM",
  },
  {
    name: "Mohammed Alrgieg",
    date: "25/05/2024 9:47 PM",
  },
]);
</script>

<style scoped></style>
