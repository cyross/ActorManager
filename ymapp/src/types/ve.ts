import type { Dictionary } from "./common";
import type { EditInfo } from "./editInfo";

export type VESpec = {
  Id: number;
  Name: string;
  RealName: string;
  Separator: string;
  Encoding: string;
  ExtData: Dictionary<string>;
};

export type VEDetail = {
  Index: number;
  Body: VESpec;
};

export type EditVEInfo = EditInfo & {
  RealName: string;
  Separator: string;
  Encoding: string;
};
