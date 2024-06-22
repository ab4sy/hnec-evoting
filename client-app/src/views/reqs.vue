<template>
  <div>
    <table class="text-xs text-left text-gray-600 table-auto w-full p-4 mt-8">
      <thead>
        <tr>
          <th class="col p-1">Full name</th>
          <th class="col p-1">Nationa lNo</th>
          <th class="col p-1">Voting Center</th>
          <th class="col p-1">Place Of Birth</th>
          <th class="col p-1">Date Of Birth</th>
          <th class="col p-1">Address</th>
          <th class="col p-1">Phone No.</th>
          <th class="col p-1">Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="o in reqs">
          <td class="p-1 whitespace-nowrap">{{ o.fullName }}</td>
          <td class="p-1 whitespace-nowrap">{{ o.nationalNo }}</td>
          <td class="p-1 whitespace-nowrap">{{ votingCenters.find((x) => x.value == o.votingCenterId)?.label }}</td>
          <td class="p-1 whitespace-nowrap">{{ o.placeOfBirth }}</td>
          <td class="p-1 whitespace-nowrap">{{ o.dateOfBirth }}</td>
          <td class="p-1 whitespace-nowrap">{{ o.address }}</td>
          <td class="p-1 whitespace-nowrap">{{ o.phoneNo }}</td>
          <td class="p-1 whitespace-nowrap">
            <div class="flex gap-4">
              <n-button size="small" v-if="o.status == 1" type="primary" class="" @click="view(o)"> View </n-button>
              <n-button size="small" v-if="o.status == 10" type="error" @click="update(o, 5)" class=""> Cancel </n-button>
              <n-button size="small" v-if="o.status == 10" type="warning"  @click="update(o, 1)" class="">Accept</n-button>
            </div>
          </td>
        </tr>
      </tbody>
    </table>

    <!-- <div v-for="o in reqs" class="bg-slate-100 w-full cursor-pointer hover:shadow-2xl flex justify-between items-center px-4 rounded-md drop-shadow-md min-h-16">
        <span>
          {{ o.fullName }}
        </span>
        <span>
          {{ votingCenters.find((x) => x.value == o.votingCenterId)?.label }}
        </span>

   
      </div> -->
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
            :value="currentCard.cardNo"
          />
        </div>

        <div class="font-semibold text-xl text-right gap-4">
          <div>الاسم : {{ currentCard.fullName }}</div>
          <div>رقم البطاقة : {{ currentCard.cardNo }}</div>
          <div>الرقم الوطني : {{ currentCard.nationalNo }}</div>
          <div>تاريخ انتهاء صلاحية البطاقة : {{ currentCard.cardExpDate }}</div>
        </div>
      </div>
    </div>
  </n-modal>
</template>

<script setup lang="ts">
import { ref, onBeforeMount } from "vue";
import QRCodeVue3 from "qrcode-vue3";
import api from "@/api/api-client";
import { AxiosResponse } from "axios";
import { NButton, NModal } from "naive-ui";
import votingCenters from "@/data/voting-centers.json";

const show_modal = ref(false as boolean);
const currentCard = ref({} as any | null);

onBeforeMount(async () => {
  await load();
});
const reqs = ref([] as any[]);

const view = (x: any) => {
  currentCard.value = x;
  show_modal.value = true;
};


const update = async (x: any, status : number) => {
  await api
    .post(`/change-status?id=${x.id}&status=${status}`)
    .then(async (response: AxiosResponse) => {
      await load();
      console.log(response);
    })
    .catch((error: any) => {
      console.log(error);
      // handle error
      // message.error(error.response.data);
    });
};


const load = async () => {
  await api
    .get(`/reqs`)
    .then(async (response: AxiosResponse) => {
      reqs.value = response.data.result;
      console.log(response);
    })
    .catch((error: any) => {
      console.log(error);
      // handle error
      // message.error(error.response.data);
    });
};
</script>

<style scoped></style>
