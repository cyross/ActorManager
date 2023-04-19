import { ref } from "vue";
import type { Ref } from "vue";
import { defineStore } from "pinia";
import type { Dictionary } from "../types/common";
import type { ColorSpec, ColorDetail } from "../types/color";
import { EmptyColorDetail  } from "../generators/color";

export const useColorStore = defineStore('color', () =>{
  const specs: Ref<Array<ColorSpec>> = ref([]);
  const dict: Ref<Dictionary<ColorSpec>> = ref({});
  const names: Ref<Array<string>> = ref([]);
  const detail: Ref<ColorDetail> = ref (EmptyColorDetail());

  const initSpecs = () => {
    specs.value = [];
  };

  const appendSpec = (spec: ColorSpec) => {
    specs.value.push(spec);
  }

  const initDict = () => {
    dict.value = {};
  };

  const setDict = (key: string, value: ColorSpec) => {
    dict.value[key] = value;
  };

  const initNames = () => {
    names.value = [];
  };

  const appendName = (name: string) => {
    names.value.push(name);
  };

  const setDetail = (index: number, spec: ColorSpec) => {
    detail.value.Index = index;
    detail.value.Body = spec;
  }

  const setSpecs = (res_specs: Array<ColorSpec>) => {
    specs.value = res_specs;
  };

  const setColorNames = () => {
    initNames();
    for (let i = 0; i < specs.value.length; i++) {
      appendName(specs.value[i].Name);
    }
  };

  const setNameToColor = () => {
    initDict();
    for (let i = 0; i < specs.value.length; i++) {
      const spec = specs.value[i];
      setDict(spec.Name, spec);
    }
  };

  const strToColor = (str: string | undefined): string => {
    if (str === undefined) {
      return "";
    }

    if (str[0] == "#") {
      return str;
    }

    return dict.value[str].Hex;
  };

  return {
    specs,
    dict,
    names,
    detail,
    initSpecs,
    appendSpec,
    initDict,
    setDict,
    initNames,
    appendName,
    setDetail,
    setSpecs,
    setColorNames,
    setNameToColor,
    strToColor,
  };
});
