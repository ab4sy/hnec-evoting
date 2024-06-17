import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";



const routes: RouteRecordRaw[] = [
  {
    path: "/",
    component: () => import("@/layouts/portal.vue"),
    children:[
      {
        path:"/",
        component: () => import("@/views/register.vue"),
      },
   
    ]
  },
  {
    path: "/voting",
    component: () => import("@/views/voting.vue"),
    children:[

   
    ]
  },
  {
    path: "/mgmt",
    component: () => import("@/layouts/mgmt.vue"),
    redirect: "/mgmt/home",
    children:[
      {
        path:"/mgmt/login",
        component: () => import("@/views/login.vue"),
      },
   
      {
        path:"/mgmt/home",
        component: () => import("@/views/home.vue"),
      },
   
    ]
  },
  // {
  //   path: "/login",
  //   component: () => import("@/views/auth/login.vue"),
  // },
 
];

const router = createRouter({
  history: createWebHistory(),
  routes: routes,
});



export default router;
