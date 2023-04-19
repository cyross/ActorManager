import type { VESpec, EditVEInfo, VEDetail } from "../types/ve";

const EmptyEditVEInfo = (): EditVEInfo => {
  return {
    Enable: false,
    Id: -1,
    Name: "",
    RealName: "",
    Separator: "",
    Encoding: "",
    ExtData: {},
  };
};

const EmptyVESpec = (): VESpec => {
  return {
    Id: -1,
    Name: "",
    RealName: "",
    Separator: "",
    Encoding: "",
    ExtData: {},
  };
};

const EmptyVEDetail = (): VEDetail => {
  return {
    Index: -1,
    Body: EmptyVESpec(),
  };
};

const InitialSepList = (): Array<string> => {
  return ["utf-8", "shift_jis"];
};

const InitialEncList = (): Array<string> => {
  return [",", "＞"];
};

export { EmptyEditVEInfo, EmptyVESpec, EmptyVEDetail, InitialSepList, InitialEncList };
