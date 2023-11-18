import type { Dictionary } from './common'
import type { EditInfo } from './editInfo'

export type ActorSpec = {
  Id: number
  Name: string
  Kana: string
  Engines: Array<string>
  PrimaryEngine: string
  AnotherNames: Array<string>
  JimakuTextColor: string
  JimakuOutlineColor: string
  JimakuOutlineWidth: number
  ActorTextColor: string
  ActorOutlineColor: string
  ActorOutlineWidth: number
  ExtData: Dictionary<string>
}

export type ActorDetail = {
  Index: number
  Body: ActorSpec
}

export type ActorColorInfo = {
  Type: string
  Name: string
  Rgb: string
}

export type ActorTextAttr = {
  TextColor: ActorColorInfo
  OutlineColor: ActorColorInfo
  OutlineWidth: number
}

export type EditActorInfo = EditInfo & {
  Kana: string
  Engines: Array<string>
  PrimaryEngine: string
  Aliases: Array<string>
  JimakuAttr: ActorTextAttr
  ActorNameAttr: ActorTextAttr
  AliasText: string
}
