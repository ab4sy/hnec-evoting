<template>
    <div class=" w-80 m-auto">

      <img  class=" w-80 mx-auto  mb-8" src="@/assets/hnec.webp" alt="" srcset="">
      <div class=" mb-4 ">
        
          <div class=" font-bold">HNEC - E-Voting Admin Panel</div>
      </div>
      <n-form class=" " ref="form_ref" :model="register">

          <n-form-item label="Username" path="fullname">
            <n-input v-model:value="register.fullname" placeholder="" />
          </n-form-item>

          <n-form-item label="Password" path="fullname">
            <n-input v-model:value="register.fullname" placeholder="" />
          </n-form-item>

    
          <n-form-item path="phone">
            <n-button type="primary"  class="w-full" @click="submit"> Login </n-button>
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

import { NForm, NFormItem, NInput, FormInst,  NButton } from "naive-ui";

import { useRouter } from "vue-router";
const router = useRouter();

// const show_modal = ref( true as boolean);
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
  localStorage.setItem("isAuth", "true");


  // form_ref.value?.validate(async (errors) => {
  //   if (!errors) {
  //     await api
  //       .post(`/api/book/`, register.value)
  //       .then(async (response: AxiosResponse) => {
  //         receipt_modal.value = true;
  //         receipt.value = response.data;

  //         // console.log(response);
  //       })
  //       .catch((error: any) => {
  //         console.log(error);
  //         // handle error
  //         // message.error(error.response.data);
  //       });
  //   }
  // });
};

onBeforeMount(async () => {
  const isAuth: string | null = localStorage.getItem("isAuth");

  if (isAuth) router.push("/mgmt/");
});
</script>

<style scoped></style>
