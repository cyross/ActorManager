import type { Dictionary } from "./common";

export type EditInfo = {
  Enable: boolean;
  Id: number;
  Name: string;
  ExtData: Dictionary<string>;
};
