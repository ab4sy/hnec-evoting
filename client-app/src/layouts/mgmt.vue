<template>
  <div class="bg-stone-300">
    <div class="h-screen mx-auto container flex justify-center items-center">


      <div class="bg-white p-6 rounded-sm drop-shadow-lg w-5/6 overflow-y-auto">
        <router-view />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { onBeforeMount } from "vue";
import { useRouter } from "vue-router";
const router = useRouter();

onBeforeMount(() => {
  const isAuth: string | null = localStorage.getItem("isAuth");

  if (!isAuth) router.push("/mgmt/login");
});
</script>

<style scoped></style>
