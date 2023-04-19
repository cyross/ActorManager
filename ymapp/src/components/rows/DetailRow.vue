<script setup lang="ts">
import { defineProps } from "vue";
import Col6TitleColumn from "../cols/Col6TitleCol.vue";

const props = defineProps({
  title: String,
  value: String,
});
</script>

<template>
  <div class="row">
    <Col6TitleColumn :title="props.title" />
    <div class="col">{{ props.value }}</div>
  </div>
</template>
