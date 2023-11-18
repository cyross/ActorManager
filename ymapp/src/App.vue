<script setup lang="ts">
import { RouterView } from 'vue-router'
import HeaderView from './components/HeaderComponent.vue'
import FooterView from './components/FooterComponent.vue'
</script>

<template>
  <div class="app">
    <HeaderView />
    <RouterView />
    <FooterView />
  </div>
</template>
