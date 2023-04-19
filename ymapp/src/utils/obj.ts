import type { Dictionary } from "../types/common";

const copyObj = (org_obj: Dictionary<string>): Dictionary<string> => {
  const new_obj: Dictionary<string> = {};

  Object.keys(org_obj).forEach((k) => (new_obj[k] = org_obj[k]));

  return new_obj;
};

const filterObj = (
  ext_data: Dictionary<string>,
  key: string | number
): Dictionary<string> => {
  if (key.toString().length === 0) {
    return ext_data;
  }
  if (key in ext_data === false) {
    return ext_data;
  }

  const new_obj: Dictionary<string> = {};
  Object.keys(ext_data).forEach((k) => {
    if (k !== key) {
      new_obj[k] = ext_data[k];
    }
  });

  return new_obj;
};

export { copyObj, filterObj };
