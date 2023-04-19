import { computed } from "vue";
import { defineStore } from "pinia";

export const useLoadCompleteStore = defineStore('loadComplete', () =>{
  let isActorLoadComplete = false;
  let isVELoadComplete = false;
  let isColorLoadComplete = false;

  const isLoadComplete = computed(() => {
    return (
      isActorLoadComplete && isVELoadComplete && isColorLoadComplete
    );
  });

  const resetActorLoadComplete = () => {
    isActorLoadComplete = false;
  };

  const resetVELoadComplete = () => {
    isVELoadComplete = false;
  };

  const resetColorLoadComplete = () => {
    isColorLoadComplete = false;
  };

  const actorLoadComplete = () => {
    isActorLoadComplete = true;
  };

  const VELoadComplete = () => {
    isVELoadComplete = true;
  };

  const colorLoadComplete = () => {
    isColorLoadComplete = true;
  };

  return {
    isActorLoadComplete,
    isVELoadComplete,
    isColorLoadComplete,
    isLoadComplete,
    resetActorLoadComplete,
    resetVELoadComplete,
    resetColorLoadComplete,
    actorLoadComplete,
    VELoadComplete,
    colorLoadComplete,
  };
});
