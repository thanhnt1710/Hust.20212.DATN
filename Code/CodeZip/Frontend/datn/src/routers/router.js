import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

const routes = [
  {
    path: "",
    component: () => import("@/Main.vue"),
    redirect: "/main/dashboard",
    meta: {
      anonymous: true,
    },
  },
  {
    path: "/",
    component: () => import("@/Main.vue"),
    redirect: "/main/dashboard",
    meta: {},
  },
  {
    path: "/login",
    component: () => import("@/layouts/TheLogin.vue"),
    meta: {},
  },
  {
    path: "/register",
    component: () => import("@/layouts/TheRegister.vue"),
    meta: {},
  },
  {
    path: "/main",
    component: () => import("@/Main.vue"),
    redirect: "/main/dashboard",
    children: [
      {
        path: "dashboard",
        name: "Dashboard",
        component: () => import("@/views/dashboard/Dashboard.vue"),
      },
      {
        path: "statistic",
        name: "Statistic",
        component: () => import("@/views/dashboard/Statistic.vue"),
      },
      {
        path: "course-detail",
        name: "CourseDetail",
        component: () => import("@/views/course/CourseDetail.vue"),
      },
      {
        path: "my-course",
        name: "ListMyCourse",
        component: () => import("@/views/course/ListMyCourse.vue"),
      },
    ],
  },

  {
    path: "/course-learn",
    name: "CourseLearn",
    component: () => import("@/views/course/CourseLearn.vue"),
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
