import type { ColorSpec, ColorDetail } from "../types/color";

export const EmptyColorSpec = (): ColorSpec => {
  return {
    Id: -1,
    Name: "",
    Hex: "",
    Type: 0,
    R: 0,
    G: 0,
    B: 0,
  };
};

export const EmptyColorDetail = (): ColorDetail => {
  return {
    Index: -1,
    Body: EmptyColorSpec(),
  };
};