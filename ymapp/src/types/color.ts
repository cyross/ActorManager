import type { Dictionary } from "./common";

export type ColorSpec = {
  Id: number;
  Name: string;
  Hex: string;
  Type: number;
  R: number;
  G: number;
  B: number;
};

export type ColorDetail = {
  Index: number;
  Body: ColorSpec;
};

export type ColorInfo = {
  IsCompleted: boolean;
  Dict: Dictionary<ColorSpec>;
  Detail: ColorDetail;
};
