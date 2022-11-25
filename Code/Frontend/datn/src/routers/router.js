import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

const routes = [
  {
    path: "",
    component: () => import('@/views/dashboard/Dashboard.vue'),
    meta: {
      anonymous: true
    },
    children: [
      {
        path: "/",
        redirect: "/dashboard",
        meta: {}
      },
      {
        path: "/dashboard",
        name: "Dashboard",
        component: () => import('@/views/dashboard/Dashboard.vue'),
      }
    ]
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
