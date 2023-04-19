<script setup lang="ts">
import { useErrorAlertStore } from "../../stores/alert";

const errorAlertStore = useErrorAlertStore();
</script>

<template>
  <div v-if="errorAlertStore.visible" class="row">
    <div class="col">
      <div class="alert alert-danger show">
        <div class="container">
          <div class="row">
            <div class="col">{{ errorAlertStore.message }}</div>
            <div class="col-1">
              <button v-on:click="errorAlertStore.hide()" type="button" class="btn btn-danger">
                <i class="bi-x-square"></i>
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
