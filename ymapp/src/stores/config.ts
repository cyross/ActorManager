import { ref } from "vue";
import { defineStore } from "pinia";

const createStore = () => {
  return () =>{
    const alertLifetime = ref(10000);
    const apiBaseURL = "http://localhost:3300";

    return { alertLifetime, apiBaseURL };
  }
};

export const useConfigStore = defineStore('config', createStore());
