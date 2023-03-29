
var app = new Vue({
    el: '#app',
    mounted: function () {
        this.updateCompleted(false)

        axios.get('/api/v1/ActorSpec/Index/')
            .then(function (response) {
                this.actor.names = response.data

                // console.log(this.actor.names)

                this.actor.load_completed = true
            }.bind(this))
        axios.get('/api/v1/VoiceEngineSpec/Index/')
            .then(function (response) {
                this.ve.names = response.data

                // console.log(this.ve.names)

                this.setupVEOptions()

                this.ve.load_completed = true
            }.bind(this))
        axios.get('/api/v1/ColorSpec/All/')
            .then(function (response) {
                this.color.specs = response.data

                this.setNameToColor()

                console.log(this.color.dict)

                this.color.load_completed = true
            }.bind(this))
    },
    computed: {
        isLoadCompleted()
        {
            return this.actor.load_completed && this.ve.load_completed && this.color.load_completed
        },
        isShowActorAddButton()
        {
            return this.actor.edit.id == -1
        },
        isShowActorUpdateButton()
        {
            return this.actor.edit.id != -1
        },
        isShowVEAddButton()
        {
            return this.ve.edit.id == -1
        },
        isShowVEUpdateButton()
        {
            return this.ve.edit.id != -1
        },
        hasActorDetail()
        {
            return this.actor.detail.body != null
        },
        visibleActorDetail()
        {
            return this.actor.detail.body != null && !this.actor.edit.enable
        },
        hasAnotherNames()
        {
            return this.actor.detail.body.AnotherNames.length==0
        },
        hasVEDetail()
        {
            return this.ve.detail.body != null
        },
        visibleVEDetail()
        {
            return this.ve.detail.body != null && !this.ve.edit.enable
        },
    },
    methods: {
        updateCompleted(flag)
        {
            this.actor.load_completed = flag;
            this.ve.load_completed = flag;
            this.color.load_completed = flag;
        },
        setupVEOptions()
        {
            this.veOptions = []
            for(idx in this.ve.names)
            {
                this.ve.options.push({text: this.ve.names[idx].Name, value: this.ve.names[idx].Name})
            }
        },
        setNameToColor()
        {
            this.color.dict = {}
            for(let i = 0; i < this.color.specs.length; i++)
            {
                var spec = this.color.specs[i]
                this.color.dict[spec.Name] = spec
            }
        },
        showActorDetail: function (index) {
            axios.get(`/api/v1/ActorSpec/${index}/`)
                .then(function (response) {
                    this.actor.detail.index = index
                    this.actor.detail.body = response.data
                    console.log(this.actor.detail.body)
                }.bind(this))
        },
        showVEDetail: function (index) {
            axios.get(`/api/v1/VoiceEngineSpec/${index}/`)
                .then(function (response) {
                    this.ve.detail.index = index
                    this.ve.detail.body = response.data
                    console.log(this.ve.detail.body)
                }.bind(this))
        },
        strToColor: function(str) {
            if (str[0] == "#"){ return str }

            return this.color.dict[str].Hex
        },
        showNewActor: function () {
            this.actor.edit.id = -1
            this.actor.edit.enable = true
        },
        showNewVE: function () {
            this.ve.edit.id = -1
            this.ve.edit.enable = true
        },
        showEditActor: function () {
            this.actor.edit.id = this.actor.detail.body.Id
            this.actor.edit.enable = true
        },
        showEditVE: function () {
            this.ve.edit.id = this.ve.detail.body.Id
            this.ve.edit.enable = true
        },
        hideEditActor: function () {
            this.actor.edit.enable = false
        },
        hideEditVE: function () {
            this.ve.edit.enable = false
        },
        addActor: function () {
            this.actor.modal_info = this.actor.edit.name
            this.$bvModal.show('confirm-add-actor')
        },
        addActorOK: function () {
            console.log('add actor ok')
            this.actor.edit.enable = false
            this.actor.detail.id = -1
            this.actor.detail.body = null
        },
        updateActor: function () {
            this.actor.modal_info = this.actor.edit.name
            this.$bvModal.show('confirm-update-actor')
        },
        updateActorOK: function () {
            console.log('update actor ok')
            this.actor.edit.enable = false
            this.actor.detail.id = -1
            this.actor.detail.body = null
        },
        deleteActor: function () {
            this.actor.modal_info = this.actor.detail.body.Name
            this.$bvModal.show('confirm-delete-actor')
        },
        deleteActorOK: function () {
            console.log('delete actor ok')
            this.actor.detail.id = -1
            this.actor.detail.body = null
        },
        addVE: function () {
            this.ve.modal_info = this.ve.edit.real_name  + '(' + this.ve.edit.name + ')'
            this.$bvModal.show('confirm-add-ve')
        },
        addVEOK: function () {
            console.log('add ve ok')
            this.ve.edit.enable = false
            this.ve.detail.id = -1
            this.ve.detail.body = null
        },
        updateVE: function () {
            this.ve.modal_info = this.ve.edit.real_name  + '(' + this.ve.edit.name + ')'
            this.$bvModal.show('confirm-update-ve')
        },
        updateVEOK: function () {
            console.log('update ve ok')
            this.ve.edit.enable = false
            this.ve.detail.id = -1
            this.ve.detail.body = null
        },
        deleteVE: function () {
            this.ve.modal_info = this.ve.detail.body.RealName + '(' + this.ve.detail.body.Name + ')'
            this.$bvModal.show('confirm-delete-ve')
        },
        deleteVEOK: function () {
            console.log('delete ve ok')
            this.ve.detail.id = -1
            this.ve.detail.body = null
        },
        saveAll: function () {
            this.$bvModal.show('confirm-save-all')
        },
        saveAllOK: function () {
            console.log('copy all ok')
        },
        revertAll: function () {
            this.$bvModal.show('confirm-revert-all')
        },
        revertAllOK: function () {
            console.log('revert all ok')
            this.updateCompleted(false)
        },
    },
    data: {
        actor: {
            load_completed: false,
            names: null,
            detail: {
                index: 0,
                body: null,
            },
            edit : {
                enable: false,
                id: -1,
                name: "",
                kana: "",
                engines: [],
                aliases: [],
                jimaku: {
                    text_color: "",
                    outline_color: "",
                    outline_width: 0,
                },
                actor: {
                    text_color: "",
                    outline_color: "",
                    outline_width: 0,
                },
                ext_data: {},
            },
            modal_info: "",
            error: {
                has: false,
                message: "",
            },
            notice: {
                has: false,
                message: "",
            },
        },
        ve: {
            load_completed: false,
            names: null,
            detail: {
                index: 0,
                body: null,
            },
            options: [],
            edit: {
                enable: false,
                id: -1,
                name: "",
                real_name: "",
                separator: "",
                encoding: "",
                ext_data: {},
            },
            modal_info: "",
            error: {
                has: false,
                message: "",
            },
            notice: {
                has: false,
                message: "",
            },
        },
        ve_san: {
            load_completed: false,
            edit: {},
        },
        color: {
            load_completed: false,
            specs: null,
            dict: {},
        },
        mng: {
            error: {
                has: false,
                message: "",
            },
            notice: {
                has: false,
                message: "",
            },
        },
    }
})
