import axios from "axios";
import type { AxiosResponse, AxiosError } from "axios";

import { useErrorAlertStore, useNoticeAlertStore } from "../stores/alert";

const errorAlertStore = useErrorAlertStore();
const noticeAlertStore = useNoticeAlertStore();

const hideAllAlert = () => {
  errorAlertStore.hide();
  noticeAlertStore.hide();
};

const thenProcess = (response: AxiosResponse, successMsg: string | null, errTitle: string | null, process: Function | null) => {
  console.log(response)
  if (response.data.Message.Status == 0) {
    if (process != null){ process(response); }

    if (successMsg != null) { noticeAlertStore.show(successMsg); }
  } else {
    if (errTitle != null) { errorAlertStore.show(`${errTitle}: ${response.data.Message.Message}`); }
  }
};

const errorProcess = (error: AxiosError, errTitle: string | null) => {
  if (errTitle != null) {
    console.log(error.message);
    errorAlertStore.show(`[FATAL]${errTitle}: ${error.message}`);
  }
};

export const callApi = (api: string, successMsg: string | null, errTitle: string | null, process: Function | null = null) => {
  hideAllAlert();

  axios
    .get(api)
    .then((response: AxiosResponse) => {
      thenProcess(response, successMsg, errTitle, process);
    })
    .catch((error: AxiosError) => {
      errorProcess(error, errTitle);
    });
};

export const callGetApi = (api: string, successMsg: string | null, errTitle: string | null, process: Function | null = null) => {
  callApi(api, successMsg, errTitle, process);
};

export const callPostApi = (api: string, data: unknown, successMsg: string | null, errTitle: string | null, process: Function | null = null) => {
  hideAllAlert();

  axios
    .post(api, data)
    .then((response: AxiosResponse) => {
      thenProcess(response, successMsg, errTitle, process);
    })
    .catch((error: AxiosError) => {
      errorProcess(error, errTitle);
    });
};

export const callPutApi = (api: string, data: unknown, successMsg: string | null, errTitle: string | null, process: Function | null = null) => {
  hideAllAlert();

  axios
    .put(api, data)
    .then((response: AxiosResponse) => {
      thenProcess(response, successMsg, errTitle, process);
    })
    .catch((error: AxiosError) => {
      errorProcess(error, errTitle);
    });
};

export const callDeleteApi = (api: string, successMsg: string | null, errTitle: string | null, process: Function | null = null) => {
  hideAllAlert();

  axios
    .delete(api)
    .then((response: AxiosResponse) => {
      thenProcess(response, successMsg, errTitle, process);
    })
    .catch((error: AxiosError) => {
      errorProcess(error, errTitle);
    });
};
