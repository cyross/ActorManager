import { ref } from "vue";
import { defineStore } from "pinia";

import { useConfigStore } from "./config";

const config =  useConfigStore();

const createStore = () => {
  return () =>{
    const visible = ref(false);
    const message = ref("");

    const show = (msg: string | null = null) => {
      if (msg != null) {
        set(msg);
      }
      visible.value = true;

      setTimeout(() => {
        visible.value = false;
      }, config.alertLifetime);
    }

    const hide = () => {
      visible.value = false;
    }

    const clear = () => {
      message.value = "";
    }

    const set = (val: string) => {
      message.value = val;
    }

    return { visible, message, show, hide, clear, set };
  }
};

export const useNoticeAlertStore = defineStore('notice', createStore());

export const useErrorAlertStore = defineStore('error', createStore());
