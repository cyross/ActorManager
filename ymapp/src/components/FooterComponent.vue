<script setup lang="ts">
import EmptyRow from "../components/rows/EmptyRow.vue";

const org_year = new Date(2023, 0, 1);
const now = new Date();

// 年が変わったら自動的に著作権表記の年表記を更新
let year_display = org_year.getFullYear().toString();
if (now.getFullYear() !== org_year.getFullYear()) {
  year_display = `${org_year.getFullYear()}-${now.getFullYear()}`;
}
</script>

<template>
  <div class="container">
    <EmptyRow />
    <div class="row">
      <div class="col">(c){{ year_display }} Cyross Makoto</div>
    </div>
  </div>
</template>
