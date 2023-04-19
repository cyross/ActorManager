import type { ActorSpec, EditActorInfo, ActorDetail, ActorTextAttr, ActorColorInfo } from "../types/actor";

export const EmptyActorTextAttr = (): ActorTextAttr => {
  return {
    TextColor: EmptyActorColorInfo(),
    OutlineColor: EmptyActorColorInfo(),
    OutlineWidth: 0,
  };
}

export const EmptyActorColorInfo = (): ActorColorInfo => {
  return {
    Type: "named",
    Name: "Black",
    Rgb: "#000000",
  };
};

export const EmptyEditActorInfo = (): EditActorInfo => {
  return {
    Enable: false,
    Id: -1,
    Name: "",
    Kana: "",
    Engines: [],
    Aliases: [],
    AliasText: "",
    JimakuAttr: EmptyActorTextAttr(),
    ActorNameAttr: EmptyActorTextAttr(),
    ExtData: {},
  };
};

export const EmptyActorSpec = (): ActorSpec => {
  return {
    Id: -1,
    Name: "",
    Kana: "",
    Engines: [],
    AnotherNames: [],
    JimakuTextColor: "",
    JimakuOutlineColor: "",
    JimakuOutlineWidth: 0,
    ActorTextColor: "",
    ActorOutlineColor: "",
    ActorOutlineWidth: 0,
    ExtData: {},
  };
};

export const EmptyActorDetail = (): ActorDetail => {
  return {
    Index: -1,
    Body: EmptyActorSpec(),
  };
};
