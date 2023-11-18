import { ref, computed } from 'vue'
import type { Ref } from 'vue'
import { defineStore } from 'pinia'

import { useColorStore } from './colors'

import type { Names } from '../types/names'
import type {
  ActorSpec,
  ActorDetail,
  EditActorInfo,
  ActorColorInfo,
  ActorTextAttr
} from '../types/actor'

import { EmptyActorDetail, EmptyEditActorInfo } from '../generators/actor'

import { copyObj, filterObj } from '../utils/obj'

const colorStore = useColorStore()

export const useActorStore = defineStore('actor', () => {
  const specs: Ref<Array<ActorSpec>> = ref([])
  const names: Ref<Array<Names>> = ref([])
  const detail: Ref<ActorDetail> = ref(EmptyActorDetail())
  const edit: Ref<EditActorInfo> = ref(EmptyEditActorInfo())

  const setSpecs = (new_specs: Array<ActorSpec>) => {
    specs.value = new_specs
  }

  const setNames = (new_names: Array<Names>) => {
    names.value = new_names
  }

  const getNamesIndex = (id: number): number => {
    return names.value.findIndex((n) => n.Id === id)
  }

  const appendName = (new_name: Names) => {
    names.value.push(new_name)
  }

  const updateName = (index: number, new_name: Names) => {
    names.value[index].Id = new_name.Id
    names.value[index].Name = new_name.Name
  }

  const updateNameById = (id: number, new_name: Names) => {
    updateName(getNamesIndex(id), new_name)
  }

  const deleteName = (index: number) => {
    names.value.splice(index, 1)
  }

  const deleteNameById = (id: number) => {
    deleteName(getNamesIndex(id))
  }

  const setDetail = (index: number, new_body: ActorSpec) => {
    detail.value = { Index: index, Body: new_body }
  }

  const resetDetail = () => {
    detail.value = EmptyActorDetail()
  }

  const applyDetailBody = (new_body: ActorSpec) => {
    detail.value.Body = new_body
  }

  const convertAliasTextToAnotherNames = (): Array<string> => {
    return edit.value.AliasText.split('\n')
      .map((alias) => alias.trim())
      .filter((alias) => alias.length != 0)
  }

  const applyDetailFromEdit = () => {
    detail.value.Body = {
      Id: edit.value.Id,
      Name: edit.value.Name,
      Kana: edit.value.Kana,
      Engines: edit.value.Engines,
      AnotherNames: convertAliasTextToAnotherNames(),
      JimakuTextColor: getColorFromInfo(edit.value.JimakuAttr.TextColor),
      JimakuOutlineColor: getColorFromInfo(edit.value.JimakuAttr.OutlineColor),
      JimakuOutlineWidth: Number(edit.value.JimakuAttr.OutlineWidth),
      ActorTextColor: getColorFromInfo(edit.value.ActorNameAttr.TextColor),
      ActorOutlineColor: getColorFromInfo(edit.value.ActorNameAttr.OutlineColor),
      ActorOutlineWidth: Number(edit.value.ActorNameAttr.OutlineWidth),
      ExtData: copyObj(edit.value.ExtData)
    }
  }

  const visibleDetail = computed(() => {
    return detail.value.Index !== -1
  })

  const titleByDetail = computed(() => {
    return `「${detail.value.Body.Name}」`
  })

  const setEdit = (new_edit_info: EditActorInfo) => {
    edit.value = new_edit_info
  }

  const newEdit = () => {
    edit.value = EmptyEditActorInfo()
    edit.value.Enable = true
  }

  const applyEditFromDetail = () => {
    edit.value.Id = detail.value.Body.Id
    edit.value.Name = detail.value.Body.Name
    edit.value.Kana = detail.value.Body.Kana
    edit.value.Engines = detail.value.Body.Engines
    edit.value.Aliases = detail.value.Body.AnotherNames
    edit.value.AliasText = edit.value.Aliases.join('\n')
    setupColor(edit.value.JimakuAttr.TextColor, detail.value.Body.JimakuTextColor)
    setupColor(edit.value.JimakuAttr.OutlineColor, detail.value.Body.JimakuOutlineColor)
    edit.value.JimakuAttr.OutlineWidth = detail.value.Body.JimakuOutlineWidth
    setupColor(edit.value.ActorNameAttr.TextColor, detail.value.Body.ActorTextColor)
    setupColor(edit.value.ActorNameAttr.OutlineColor, detail.value.Body.ActorOutlineColor)
    edit.value.ActorNameAttr.OutlineWidth = detail.value.Body.ActorOutlineWidth
    edit.value.ExtData = copyObj(detail.value.Body.ExtData)
    edit.value.Enable = true
  }

  const addExtData = (key: string, value: string) => {
    // リアクティブにさせるために遠回りの対応をしている
    const ext = copyObj(edit.value.ExtData)
    ext[key] = value
    edit.value.ExtData = ext
  }

  const removeExtData = (key: string) => {
    // リアクティブにさせるために遠回りの対応をしている
    const value = edit.value
    value.ExtData = filterObj(value.ExtData, key)
    edit.value = value
  }

  const editEnable = () => {
    edit.value.Enable = true
  }

  const editDisable = () => {
    edit.value.Enable = false
  }

  const visibleEdit = computed(() => {
    return edit.value.Enable
  })

  const isAdd = computed(() => {
    return edit.value.Id === -1
  })

  const isUpdate = computed(() => {
    return edit.value.Id !== -1
  })

  const modalInfoByEdit = computed(() => {
    return edit.value.Name
  })

  const titleByEdit = computed(() => {
    return `「${edit.value.Name}」`
  })

  const strToColor = (str: string): string => {
    if (str[0] == '#') {
      return str
    }

    return colorStore.dict[str].Hex
  }

  const getColorType = (colorString: string): string => {
    if (colorString[0] == '#') {
      return 'rgb'
    }

    return 'named'
  }

  const setColorType = (info: ActorColorInfo, colorType: string): void => {
    info.Type = colorType
  }

  const getColorRGB = (colorString: string): string => {
    if (colorString[0] == '#') {
      return colorString
    }

    return colorStore.dict[colorString].Hex
  }

  const setupColor = (info: ActorColorInfo, color: string) => {
    info.Type = getColorType(color)
    info.Name = color
    info.Rgb = getColorRGB(color)
  }

  const getColorFromInfo = (info: ActorColorInfo): string => {
    if (info.Type === 'named') {
      return info.Name
    }

    return info.Rgb
  }

  const selectChangedColor = (info: ActorColorInfo, name: string) => {
    info.Name = name
    info.Rgb = getColorRGB(info.Name)
  }

  const selectRgb = (info: ActorColorInfo, rgb: string) => {
    info.Rgb = rgb
  }

  const copyEditActorColorInfo = (from: ActorColorInfo, to: ActorColorInfo) => {
    to.Type = from.Type
    to.Name = from.Name
    to.Rgb = from.Rgb
  }

  const copyEditTextInfo = (from: ActorTextAttr, to: ActorTextAttr) => {
    copyEditActorColorInfo(from.TextColor, to.TextColor)
    copyEditActorColorInfo(from.OutlineColor, to.OutlineColor)
    to.OutlineWidth = from.OutlineWidth
  }

  return {
    specs,
    names,
    detail,
    edit,
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
    strToColor,
    selectChangedColor,
    selectRgb,
    copyEditTextInfo,
    setColorType
  }
})
