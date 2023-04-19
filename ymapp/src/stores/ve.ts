import { ref, computed } from "vue";
import type { Ref } from "vue";
import { defineStore } from "pinia";

import type { Names } from "../types/names";
import type { VESpec, VEDetail, EditVEInfo } from "../types/ve";

import { EmptyVEDetail, EmptyEditVEInfo, InitialSepList, InitialEncList } from "../generators/ve";

import { copyObj, filterObj } from "../utils/obj";

export const useVEStore = defineStore('ve', () =>{
  const specs: Ref<Array<VESpec>> = ref([]);
  const names: Ref<Array<Names>> = ref([]);
  const detail: Ref<VEDetail> = ref(EmptyVEDetail());
  const edit: Ref<EditVEInfo> = ref(EmptyEditVEInfo());
  const options: Ref<Array<string>> = ref([]);
  const encodes: Ref<Array<string>> = ref(InitialEncList());
  const separators: Ref<Array<string>> = ref(InitialSepList());

  const setSpecs = (new_specs: Array<VESpec>) => {
    specs.value = new_specs;

    createOptions();
  };

  const setNames = (new_names: Array<Names>) => {
    names.value = new_names;
  };

  const getNamesIndex = (id: number): number => {
    return names.value.findIndex((n) => n.Id === id);
  };

  const appendName = (new_name: Names) => {
    names.value.push(new_name);
  };

  const updateName = (index: number, new_name: Names) => {
    names.value[index].Id = new_name.Id;
    names.value[index].Name = new_name.Name;
  };

  const updateNameById = (id: number, new_name: Names) => {
    updateName(getNamesIndex(id), new_name);
  };

  const deleteName = (index: number) => {
    names.value.splice(index, 1);
  }

  const deleteNameById = (id: number) => {
    deleteName(getNamesIndex(id));
  }

  const setDetail = (index: number, new_body: VESpec) => {
    detail.value = { Index: index, Body: new_body };
  };

  const resetDetail = () => {
    detail.value = EmptyVEDetail();
  };

  const applyDetailBody = (new_body: VESpec) => {
    detail.value.Body = new_body;
  };

  const applyDetailFromEdit = (editBody: EditVEInfo) => {
    detail.value.Body.Id = editBody.Id;
    detail.value.Body.Name = editBody.Name;
    detail.value.Body.RealName = editBody.RealName;
    detail.value.Body.Encoding = editBody.Encoding;
    detail.value.Body.Separator = editBody.Separator;
    detail.value.Body.ExtData = copyObj(editBody.ExtData);
  };

  const visibleDetail = computed(() => {
    return detail.value.Index !== -1;
  });

  const titleByDetail = computed(() => {
    return detail.value.Body.RealName + "(" + detail.value.Body.Name + ")";
  });

  const setEdit = (new_edit_info: EditVEInfo) => {
    edit.value = new_edit_info;
  };

  const newEdit = () => {
    edit.value.Id = -1;
    edit.value.Name = "";
    edit.value.RealName = "";
    edit.value.Encoding = encodes.value[0];
    edit.value.Separator = separators.value[0];
    edit.value.ExtData = {};
    edit.value.Enable = true;
  };

  const applyEditFromDetail = () => {
    edit.value.Id = detail.value.Body.Id;
    edit.value.Name = detail.value.Body.Name;
    edit.value.RealName = detail.value.Body.RealName;
    edit.value.Encoding = detail.value.Body.Encoding;
    edit.value.Separator = detail.value.Body.Separator;
    edit.value.ExtData = copyObj(detail.value.Body.ExtData);
  };

  const addExtData = (key: string, value: string) => {
    // リアクティブにさせるために遠回りの対応をしている
    const ext = copyObj(edit.value.ExtData);
    ext[key] = value;
    edit.value.ExtData = ext;
  }

  const removeExtData = (key: string) => {
    // リアクティブにさせるために遠回りの対応をしている
    const value = edit.value;
    value.ExtData = filterObj(value.ExtData, key);
    edit.value = value;
  }

  const editEnable = () => {
    edit.value.Enable = true;
  }

  const editDisable = () => {
    edit.value.Enable = false;
  }

  const visibleEdit = computed(() => {
    return edit.value.Enable;
  });

  const isAdd = computed(() =>{
    return edit.value.Id === -1;
  });

  const isUpdate = computed(() => {
    return edit.value.Id !== -1;
  });

  const modalInfoByEdit = computed(() => {
    return edit.value.RealName + "(" + edit.value.Name + ")";
  });

  const titleByEdit = computed(() => {
    return `「${edit.value.Name}」`;
  });

  const titleByDetailAndEdit = computed(() => {
    return detail.value.Body.RealName + "(" + edit.value.Name + ")";
  });

  const createOptions = () => {
    options.value = [];

    specs.value.forEach((spec) => {
      options.value.push(spec.Name);
    });
  };

  return {
    specs,
    names,
    detail,
    edit,
    options,
    encodes,
    separators,
    setSpecs,
    setNames,
    getNamesIndex,
    appendName,
    updateName,
    updateNameById,
    deleteName,
    deleteNameById,
    setDetail,
    resetDetail,
    applyDetailBody,
    applyDetailFromEdit,
    visibleDetail,
    titleByDetail,
    setEdit,
    newEdit,
    applyEditFromDetail,
    addExtData,
    removeExtData,
    editEnable,
    editDisable,
    visibleEdit,
    isAdd,
    isUpdate,
    modalInfoByEdit,
    titleByEdit,
    titleByDetailAndEdit,
    createOptions,
  }
});
