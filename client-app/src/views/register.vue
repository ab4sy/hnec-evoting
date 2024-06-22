<template>
  <div class="">
    <img class="w-80 mx-auto mb-8" src="@/assets/hnec.webp" alt="" srcset="" />
    <div class="mb-4">
      <div class="text-xl">Welcome</div>
      <div class="font-bold">HNEC - E-Voting Portal</div>
    </div>
    <n-form class="flex flex-col gap-4" ref="form_ref" :model="register" :rules="reg_rules">
      <n-form-item label="Full name" path="fullName">
        <n-input v-model:value="register.fullName" placeholder="" />
      </n-form-item>

      <n-form-item label="National No." path="nationalNo">
        <n-input v-model:value="register.nationalNo" placeholder="" />
      </n-form-item>

      <n-form-item label="Date of birth" path="dateOfBirth">
        <n-date-picker class="w-full" v-model:formatted-value="register.dateOfBirth" value-format="yyyy-MM-dd" type="date" clearable />
      </n-form-item>

      <n-form-item label="Place of birth" path="placeOfBirth">
        <n-input v-model:value="register.placeOfBirth" placeholder="" />
      </n-form-item>

      <n-form-item label="Voting center" path="votingCenterId">
        <n-select v-model:value="register.votingCenterId" filterable placeholder="" :options="votingCenters" />
      </n-form-item>

      <n-form-item label="Address" path="address">
        <n-input v-model:value="register.address" placeholder="" />
      </n-form-item>
      <n-form-item label="Passport" path="passport">
        <n-input v-model:value="register.passport" placeholder="" />
      </n-form-item>
      <n-form-item label="Phone No." path="phoneNo">
        <n-input v-model:value="register.phoneNo" placeholder="" />
      </n-form-item>
      <n-form-item label="Email" path="email">
        <n-input v-model:value="register.email" placeholder="" />
      </n-form-item>

      <n-form-item path="phone">
        <n-button type="primary" class="w-full" @click="submit"> Save </n-button>
      </n-form-item>
    </n-form>

    <n-modal v-model:show="success_modal">
      <div class="bg-white w-80 p-8 rounded-md">
        <n-result status="success" title="Success" description="Thank you for registration">
          <template #footer>
            <div class="my-4">We'll notify you via SMS when your e-election card is ready!</div>
            <n-button @click="success_modal = false">Ok!</n-button>
          </template>
        </n-result>
      </div>
    </n-modal>

    <n-modal v-model:show="otp_modal">
      <div class="bg-white w-80 p-8 flex flex-col gap-4 rounded-md">
        <div class="text-xl font-bold">Please enter otp</div>

        <n-form class="flex flex-col gap-4" ref="otp_ref" :model="register" :rules="reg_rules">
          <n-form-item label="Verification code" path="otp">
            <n-input v-model:value="register.otp" placeholder="OTP" />
          </n-form-item>
        </n-form>

        <n-button type="primary" @click="verfiy">Verfiy</n-button>
      </div>
    </n-modal>
  </div>
</template>

<script setup lang="ts">
import api from "@/api/api-client";

import { reg_rules } from "@/views/rules";

import { ref, onBeforeMount } from "vue";
import { AxiosResponse } from "axios";

import votingCenters from "@/data/voting-centers.json";

import { NForm, NFormItem, NInput, FormInst, NDatePicker, NButton, NModal, NResult, NSelect, useMessage } from "naive-ui";

const success_modal = ref(false as boolean);
const otp_modal = ref(false as boolean);
const register = ref({} as any);
const message = useMessage();

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
const otp_ref = ref<FormInst | null>(null);

const submit = () => {
  form_ref.value?.validate(async (errors) => {
    if (!errors) {
      await api
        .post(`/otp?PhoneNo=${register.value.phoneNo}`)
        .then(async (response: AxiosResponse) => {
          console.log(response);
          register.value.token = response.data.token;
          otp_modal.value = true;
        })
        .catch((error: any) => {
          console.log(error);
          // handle error
          // message.error(error.response.data);
        });
    }
  });
};

const verfiy = () => {
  otp_ref.value?.validate(async (errors) => {
    if (!errors) {
      await api
        .post(`/register`, register.value)
        .then(async (response: AxiosResponse) => {
          console.log(response);


          register.value.fullName ="";
          register.value.nationalNo="";
          register.value.dateOfBirth=null;
          register.value.placeOfBirth="";
          register.value.address="";
          register.value.votingCenterId=null;
          register.value.phoneNo="";
          register.value.passport="";
          register.value.token="";
          register.value.otp="";
          register.value.email="";
        


          otp_modal.value = false;
          success_modal.value = true;
        })
        .catch((error: any) => {
          console.log(error);
          message.error(error.response.data.message);

          // handle error
          // message.error(error.response.data);
        });
    }
  });
};

onBeforeMount(async () => {});
</script>

<style scoped></style>
