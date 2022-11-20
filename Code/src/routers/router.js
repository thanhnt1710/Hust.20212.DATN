import { createRouter, createWebHistory } from "vue-router";
const Foo = { template: "<div>foo</div>" };
const Bar = { template: "<div>bar</div>" };
const routes = [
  { path: "/foo", component: Foo },
  { path: "/bar", component: Bar },
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
