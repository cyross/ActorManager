
var app = new Vue({
    el: '#app',
    mounted: function () {
        axios.get('/api/v1/ActorSpec/Index/')
            .then(function (response) {
                this.actorNames = response.data
                // console.log(this.actorNames)
            }.bind(this))
        axios.get('/api/v1/VoiceEngineSpec/Index/')
            .then(function (response) {
                this.veNames = response.data
                // console.log(this.veNames)
            }.bind(this))
        axios.get('/api/v1/ColorSpec/All/')
            .then(function (response) {
                this.colorSpecs = response.data
                for(let i = 0; i < this.colorSpecs.length; i++)
                {
                    var spec = this.colorSpecs[i]
                    this.nameToColor[spec.Name] = spec
                }
                console.log(this.nameToColor)
            }.bind(this))
    },
    methods: {
        showActorDetail: function (index) {
            axios.get(`/api/v1/ActorSpec/${index}/`)
                .then(function (response) {
                    this.actorDetailIndex = index
                    this.actorDetail = response.data
                    console.log(this.actorDetail)
                }.bind(this))
        },
        showVEDetail: function (index) {
            axios.get(`/api/v1/VoiceEngineSpec/${index}/`)
                .then(function (response) {
                    this.veDetailIndex = index
                    this.veDetail = response.data
                    console.log(this.veDetail)
                }.bind(this))
        },
        showNewActor: function () {
        },
        showNewVE: function () {
        },
        strToColor: function(str) {
            if (str[0] == "#"){ return str }

            return this.nameToColor[str].Hex
        },
    },
    data: {
        actorNames: null,
        actorDetailIndex: 0,
        actorDetail: null,
        actorHasError: false,
        actorErrorMsg: "",
        actorHasNotice: false,
        actorNoticeMsg: "",
        actorEditId: -1,
        actorEditName: "",
        actorEditKana: "",
        actorEditEngines: [],
        actorEditAliases: [],
        actorEditJimakuColorName: "",
        actorEditJimakuColorHex: "#000000",
        actorEditJimakuColorR: 0,
        actorEditJimakuColorG: 0,
        actorEditJimakuColorB: 0,
        actorEditActorColorName: "",
        actorEditActorColorHex: "#000000",
        actorEditActorColorR: 0,
        actorEditActorColorG: 0,
        actorEditActorColorB: 0,
        actorEditExtData: {},
        veNames: null,
        veDetailIndex: 0,
        veDetail: null,
        veHasError: false,
        veErrorMsg: "",
        veHasNotice: false,
        noticeMsg: "",
        colorSpecs: null,
        nameToColor: {},
    }
})
