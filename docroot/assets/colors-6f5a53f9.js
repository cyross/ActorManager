import{e as m,r as n}from"./index-8cce3018.js";const d=()=>({Id:-1,Name:"",Hex:"",Type:0,R:0,G:0,B:0}),C=()=>({Index:-1,Body:d()}),T=m("color",()=>{const o=n([]),s=n({}),a=n([]),l=n(C()),p=()=>{o.value=[]},v=e=>{o.value.push(e)},c=()=>{s.value={}},r=(e,t)=>{s.value[e]=t},u=()=>{a.value=[]},i=e=>{a.value.push(e)};return{specs:o,dict:s,names:a,detail:l,initSpecs:p,appendSpec:v,initDict:c,setDict:r,initNames:u,appendName:i,setDetail:(e,t)=>{l.value.Index=e,l.value.Body=t},setSpecs:e=>{o.value=e},setColorNames:()=>{u();for(let e=0;e<o.value.length;e++)i(o.value[e].Name)},setNameToColor:()=>{c();for(let e=0;e<o.value.length;e++){const t=o.value[e];r(t.Name,t)}},strToColor:e=>e===void 0?"":e[0]=="#"?e:s.value[e].Hex}});export{T as u};