var app = new Vue({
    el: '#app',
    mounted: function () {
        axios.get('/api/v1/ActorSpec/Index/')
            .then(function (response) {
                this.actorNames = response.data
                console.log(this.actorNames)
            }.bind(this))
        axios.get('/api/v1/VoiceEngineSpec/Index/')
            .then(function (response) {
                this.veNames = response.data
                console.log(this.veNames)
            }.bind(this))
        axios.get('/api/v1/ColorSpec/Index/')
            .then(function (response) {
                this.colorNames = response.data
                console.log(this.colorNames)
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
        showColorDetail: function (index) {
            axios.get(`/api/v1/ColorSpec/${index}/`)
                .then(function (response) {
                    this.colorDetailIndex = index
                    this.colorDetail = response.data
                    console.log(this.colorDetail)
                }.bind(this))
        }
    },
    data: {
        actorNames: null,
        actorNamesFields: ['Name'],
        actorDetailIndex: 0,
        actorDetail: null,
        veNames: null,
        veNamesFields: ['Name'],
        veDetailIndex: 0,
        veDetail: null,
        colorNames: null,
        colorNamesFields: ['Hex', 'Name'],
        colorDetailIndex: 0,
        colorDetail: null,
    }
})
