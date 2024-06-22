<template>
  <div class="w-80 m-auto">
    <img class="w-80 mx-auto mb-8" src="@/assets/hnec.webp" alt="" srcset="" />
    <div class="mb-4">
      <div class="font-bold">HNEC - E-Voting Admin Panel</div>
    </div>
    <n-form class=" " ref="form_ref" :model="login" :rules="login_rules">
      <n-form-item label="Username" path="username">
        <n-input v-model:value="login.username" placeholder="" />
      </n-form-item>

      <n-form-item label="Password" path="password">
        <n-input type="password" v-model:value="login.password" placeholder="" />
      </n-form-item>

      <n-form-item path="phone">
        <n-button type="primary" class="w-full" @click="submit"> Login </n-button>
      </n-form-item>
    </n-form>

    <!-- <n-modal v-model:show="show_modal">
   <div class=" bg-white w-80 p-8 rounded-md">
    <n-result status="success" title="Success" description="Thank you for registration">
    <template  #footer>
      <div class=" my-4">We'll notify you via SMS when your e-election card is ready!</div>
      <n-button @click="show_modal=false">Ok!</n-button>
    </template>
  </n-result>

   </div>
  </n-modal> -->
  </div>
</template>

<script setup lang="ts">
import { ref, onBeforeMount } from "vue";

import { NForm, NFormItem, NInput, FormInst, NButton,useMessage } from "naive-ui";
import { login_rules } from "@/views/rules";

import { useRouter } from "vue-router";
const router = useRouter();

const message = useMessage();

// const show_modal = ref( true as boolean);
const login = ref({} as any);
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
      if (login.value.username == "admin" && login.value.password == "123456") {
        localStorage.setItem("isAuth", "true");
        router.push("/mgmt");
      }else{
        login.value.username="";
        login.value.password="";
        message.error("invaild user");


      }
    }
  });
};

onBeforeMount(async () => {
  const isAuth: string | null = localStorage.getItem("isAuth");

  if (isAuth) router.push("/mgmt/");
});
</script>

<style scoped></style>
