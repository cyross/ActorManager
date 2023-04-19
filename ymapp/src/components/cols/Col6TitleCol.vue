<script setup lang="ts">
import { defineProps } from "vue";

const props = defineProps({
  title: String,
});
</script>

<template>
  <div class="col-6">{{ props.title }}</div>
</template>
