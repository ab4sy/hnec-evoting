<template>
    <div class="">

      <img  class=" w-80 mx-auto  mb-8" src="@/assets/hnec.webp" alt="" srcset="">
      <div class=" mb-4 ">
        
        <div class=" text-xl">Welcome</div>
          <div class=" font-bold">HNEC - E-Voting Portal</div>
      </div>
      <n-form class=" " ref="form_ref" :model="register">

          <n-form-item label="Full name" path="fullname">
            <n-input v-model:value="register.fullname" placeholder="" />
          </n-form-item>

          <n-form-item label="Nanation No." path="nationalNo">
            <n-input v-model:value="register.nationalNo" placeholder="" />
          </n-form-item>

          <n-form-item label="Date of birth" path="dateOfBirth">
            <n-date-picker  class=" w-full" v-model:formatted-value="register.dateOfBirth" value-format="yyyy-MM-dd" type="date" clearable />
          </n-form-item>

          <n-form-item label="Place of birth" path="placeOfBirth">
            <n-input v-model:value="register.placeOfBirth" placeholder="" />
          </n-form-item>

          <n-form-item  label="Place of election" path="municipalityId">
              <n-select v-model:value="register.municipalityId" filterable placeholder="" :options="data" />
            </n-form-item>


          <n-form-item label="Address" path="phoneNo">
            <n-input v-model:value="register.address" placeholder="" />
          </n-form-item>
          <n-form-item label="Passport" path="phoneNo">
            <n-input v-model:value="register.address" placeholder="" />
          </n-form-item>
          <n-form-item label="Phone No." path="phone">
            <n-input v-model:value="register.phoneNo" placeholder="Phone Number" />
          </n-form-item>
          <n-form-item path="phone">
            <n-button type="primary"  class="w-full" @click="submit"> Save </n-button>
          </n-form-item>

    
      </n-form>

 <n-modal v-model:show="show_modal">
   <div class=" bg-white w-80 p-8 rounded-md">
    <n-result status="success" title="Success" description="Thank you for registration">
    <template  #footer>
      <div class=" my-4">We'll notify you via SMS when your e-election card is ready!</div>
      <n-button @click="show_modal=false">Ok!</n-button>
    </template>
  </n-result>

   </div>
  </n-modal>


    </div>

</template>

<script setup lang="ts">
import api from "@/api/api-client";

import { ref, onBeforeMount } from "vue";
import { AxiosResponse } from "axios";

import data from "../data/places.json";


import { NForm, NFormItem, NInput, FormInst, NDatePicker, NButton , NModal, NResult, NSelect} from "naive-ui";
const receipt_modal = ref(false);
const receipt = ref({} as any);

const show_modal = ref( false as boolean);
const register = ref({} as any);
// const message = useMessage();

// const current = ref<number>(1);

// const next = () => {
//   if (current.value === 4) return;
//   else current.value++;
// };

// const prev = () => {
//   if (current.value === 1) return;
//   current.value--;
// };

const form_ref = ref<FormInst | null>(null);

const submit = () => {
  form_ref.value?.validate(async (errors) => {
    if (!errors) {
      await api
        .post(`/api/book/`, register.value)
        .then(async (response: AxiosResponse) => {
          receipt_modal.value = true;
          receipt.value = response.data;

          // console.log(response);
        })
        .catch((error: any) => {
          console.log(error);
          // handle error
          // message.error(error.response.data);
        });
    }
  });
};

onBeforeMount(async () => {});
</script>

<style scoped></style>
