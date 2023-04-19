import type { AxiosResponse } from "axios";

import { useConfigStore } from "../../stores/config";

import { callApi } from "../../utils/apiCall";

const configStore = useConfigStore();

const colorSpecsApi: string = `${configStore.apiBaseURL}/api/v1/ColorSpec/All/`;

export const getColorSpecs = (callback: Function) => {
  callApi(
    colorSpecsApi,
    null,
    "色情報取得エラー",
    (response: AxiosResponse) => {
      return callback(response);
    }
  );
};
