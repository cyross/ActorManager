import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: () => import("../views/MngView.vue"),
    },
    {
      path: '/actorMaster',
      name: 'actorMaster',
      component: () => import("../views/ActorMasterView.vue"),
    },
    {
      path: '/veMaster',
      name: 'veMaster',
      component: () => import("../views/VEMasterView.vue"),
    },
    {
      path: '/colorMaster',
      name: 'colorMaster',
      component: () => import("../views/ColorMasterView.vue"),
    },
    {
      path: '/sanitizeRe',
      name: 'sanitizeRe',
      component: () => import("../views/MngView.vue"),
    },
    {
      path: '/encodings',
      name: 'encodings',
      component: () => import("../views/MngView.vue"),
    },
    {
      path: '/separators',
      name: 'separators',
      component: () => import("../views/MngView.vue"),
    },
    {
      path: '/colorList',
      name: 'colorList',
      component: () => import("../views/ColorView.vue"),
    },
  ]
})

export default router
