
var app = new Vue({
    el: '#app',
    mounted: function () {
        this.setUp()
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
        hasError()
        {
            return this.actor.error.has || this.ve.error.has || this.color.error.has || this.ve_san.error.has || this.ve_none.error.has || this.ve_sep.error.has || this.mng.error.has
        },
        hasNotice()
        {
            return this.actor.notice.has || this.ve.notice.has || this.color.notice.has || this.ve_san.notice.has || this.ve_none.notice.has || this.ve_sep.notice.has || this.mng.notice.has
        },
    },
    methods: {
        setUp()
        {
            this.updateCompleted(false)

            axios.get('/api/v1/ActorSpec/Index/')
                .then(function (response) {
                    if(response.data.Message.Status == 0)
                    {
                        this.actor.names = response.data.Names
                        this.actor.load_completed = true
                    }
                    else
                    {
                        this.clearError()
                        this.actor.error.has = true
                        this.actor.error.message = `声優一覧取得エラー: ${response.data.Message.Message}`
                    }
                }.bind(this))
            axios.get('/api/v1/VoiceEngineSpec/Index/')
                .then(function (response) {
                    if(response.data.Message.Status == 0)
                    {
                        this.ve.names = response.data.Names

                        this.setupVEOptions()

                        this.ve.load_completed = true
                    }
                    else
                    {
                        this.clearError()
                        this.ve.error.has = true
                        this.ve.error.message = `音声合成エンジン一覧取得エラー: ${response.data.Message.Message}`
                    }
                }.bind(this))
            axios.get('/api/v1/ColorSpec/All/')
                .then(function (response) {
                    if(response.data.Message.Status == 0)
                    {
                        this.color.specs = response.data.Specs

                        this.setColorNames()
                        this.setNameToColor()

                        this.color.load_completed = true
                    }
                    else
                    {
                        this.clearError()
                        this.color.error.has = true
                        this.color.error.message = `色情報取得エラー: ${response.data.Message.Message}`
                    }
                }.bind(this))
            },
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
            setColorNames()
            {
                this.color.names = []
                for(let i = 0; i < this.color.specs.length; i++)
                {
                    var spec = this.color.specs[i]
                    this.color.names.push(spec.Name)
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
                        if(response.data.Message.Status == 0)
                        {
                            this.actor.detail.index = index
                            this.actor.detail.body = response.data.Spec

                            this.clearNotice()
                        }
                        else
                        {
                            this.clearError()
                            this.actor.error.has = true
                            this.actor.error.message = `声優詳細取得エラー: ${response.data.Message.Message}`
                        }
                    }.bind(this))
            },
            showVEDetail: function (index) {
                axios.get(`/api/v1/VoiceEngineSpec/${index}/`)
                    .then(function (response) {
                        if(response.data.Message.Status == 0)
                        {
                            this.ve.detail.index = index
                            this.ve.detail.body = response.data.Spec

                            this.clearNotice()
                        }
                        else
                        {
                            this.clearError()
                            this.ve.error.has = true
                            this.ve.error.message = `音声合成エンジン詳細取得エラー: ${response.data.Message.Message}`
                        }
                    }.bind(this))
        },
        showColorDetail: function (id) {
            this.color.detail.id = id
            this.color.detail.body = this.color.specs.find(spec => spec.Id === id)
        },
        strToColor: function(str) {
            if (str[0] == "#"){ return str }

            return this.color.dict[str].Hex
        },
        clearError: function()
        {
            this.actor.error.message = ""
            this.ve.error.message = ""
            this.color.error.message = ""
            this.ve_san.error.message = ""
            this.ve_none.error.message = ""
            this.ve_sep.error.message = ""
            this.mng.error.message = ""
        },
        clearNotice: function()
        {
            this.actor.notice.message = ""
            this.ve.notice.message = ""
            this.color.notice.message = ""
            this.ve_san.notice.message = ""
            this.ve_none.notice.message = ""
            this.ve_sep.notice.message = ""
            this.mng.notice.message = ""
        },
        hideError: function() {
            this.actor.error.has = false
            this.ve.error.has = false
            this.color.error.has = false
            this.ve_san.error.has = false
            this.ve_none.error.has = false
            this.ve_sep.error.has = false
            this.mng.error.has = false
        },
        hideNotice: function() {
            this.actor.notice.has = false
            this.ve.notice.has = false
            this.color.notice.has = false
            this.ve_san.notice.has = false
            this.ve_none.notice.has = false
            this.ve_sep.notice.has = false
            this.mng.notice.has = false
        },
        showNewActor: function () {
            this.actor.edit.id = -1
            this.actor.edit.name = ""
            this.actor.edit.kana = ""
            this.actor.edit.engines = []
            this.actor.edit.aliases = []
            this.setupColor(this.actor.edit.jimaku.text_color, "Black")
            this.setupColor(this.actor.edit.jimaku.outline_color, "White")
            this.actor.edit.jimaku.outline_width = 0
            this.setupColor(this.actor.edit.actor_name.text_color, "Black")
            this.setupColor(this.actor.edit.actor_name.outline_color, "White")
            this.actor.edit.actor_name.outline_width = 0
            this.actor.edit.ext_data = {}
            this.actor.edit.enable = true
        },
        showNewVE: function () {
            this.ve.edit.id = -1
            this.ve.edit.name = ""
            this.ve.edit.real_name = ""
            this.ve.edit.separator = ""
            this.ve.edit.encoding = ""
            this.ve.edit.ext_data = {}
            this.ve.edit.enable = true
        },
        showEditActor: function () {
            this.actor.edit.id = this.actor.detail.body.Id
            this.actor.edit.name = this.actor.detail.body.Name
            this.actor.edit.kana = this.actor.detail.body.Kana
            this.actor.edit.engines = this.actor.detail.body.Engines
            this.actor.edit.aliases = this.actor.detail.body.AnotherNames
            this.actor.edit.alias_text = this.actor.edit.aliases.join('\n')
            this.setupColor(this.actor.edit.jimaku.text_color, this.actor.detail.body.JimakuTextColor)
            this.setupColor(this.actor.edit.jimaku.outline_color, this.actor.detail.body.JimakuOutlineColor)
            this.actor.edit.jimaku.outline_width = this.actor.detail.body.JimakuOutlineWidth
            this.setupColor(this.actor.edit.actor_name.text_color, this.actor.detail.body.ActorTextColor)
            this.setupColor(this.actor.edit.actor_name.outline_color, this.actor.detail.body.ActorOutlineColor)
            this.actor.edit.actor_name.outline_width = this.actor.detail.body.ActorOutlineWidth
            this.actor.edit.ext_data = this.copyObj(this.actor.detail.body.ExtData)
            this.actor.edit.enable = true
        },
        showEditVE: function () {
            this.ve.edit.id = this.ve.detail.body.Id
            this.ve.edit.name = this.ve.detail.body.Name
            this.ve.edit.real_name = this.ve.detail.body.RealName
            this.ve.edit.separator = this.ve.detail.body.Separator
            this.ve.edit.encoding = this.ve.detail.body.Encoding
            this.ve.edit.ext_data = this.copyObj(this.ve.detail.body.ExtData)
            this.ve.edit.enable = true
        },
        hideEditActor: function () {
            this.actor.edit.enable = false
        },
        hideEditVE: function () {
            this.ve.edit.enable = false
        },
        addActorExt: function () {
            this.$set(this.actor.edit.ext_data, this.actor.edit.ext_key, this.actor.edit.ext_value)
            this.actor.edit.ext_key = ""
            this.actor.edit.ext_value = ""
        },
        deleteActorExt: function (key) {
            this.actor.edit.ext_data = this.filterObj(this.actor.edit.ext_data, key)
        },
        addVEExt: function () {
            this.$set(this.ve.edit.ext_data, this.ve.edit.ext_key, this.ve.edit.ext_value)
            this.ve.edit.ext_key = ""
            this.ve.edit.ext_value = ""
        },
        deleteVEExt: function (key) {
            this.ve.edit.ext_data = this.filterObj(this.ve.edit.ext_data, key)
        },
        applyActor: function() {
            this.actor.detail.body = {
                Id: this.actor.edit.id,
                Name: this.actor.edit.name,
                Kana: this.actor.edit.kana,
                Engines: this.actor.edit.engines,
                AnotherNames: this.actor.edit.alias_text.split('\n').map(alias => alias.trim()).filter(alias => alias.length != 0),
                JimakuTextColor: this.getColorFromInfo(this.actor.edit.jimaku.text_color),
                JimakuOutlineColor: this.getColorFromInfo(this.actor.edit.jimaku.outline_color),
                JimakuOutlineWidth: parseFloat(this.actor.edit.jimaku.outline_width),
                ActorTextColor: this.getColorFromInfo(this.actor.edit.actor_name.text_color),
                ActorOutlineColor: this.getColorFromInfo(this.actor.edit.actor_name.outline_color),
                ActorOutlineWidth: parseFloat(this.actor.edit.actor_name.outline_width),
                ExtData: this.copyObj(this.actor.edit.ext_data),
            }
        },
        addActor: function () {
            this.actor.modal_info = this.actor.edit.name
            this.$bvModal.show('confirm-add-actor')
        },
        appendActor: function () {
            this.actor.modal_info = this.actor.edit.name
            this.$bvModal.show('confirm-add-actor')
        },
        addActorOK: function () {
            this.applyActor()
            this.callAddApi('ActorSpec', this.actor, `「${this.actor.edit.name}」`)
        },
        updateActor: function () {
            this.actor.modal_info = this.actor.edit.name
            this.$bvModal.show('confirm-update-actor')
        },
        updateActorOK: function () {
            this.applyActor()
            this.callUpdateApi('ActorSpec', this.actor, `「${this.actor.edit.name}」`)
        },
        deleteActor: function () {
            this.actor.modal_info = this.actor.detail.body.Name
            this.$bvModal.show('confirm-delete-actor')
        },
        deleteActorOK: function () {
            this.callDeleteApi('ActorSpec', this.actor, `「${this.actor.detail.body.Name}」`)
        },
        applyVE: function() {
            this.ve.detail.body = {
                Id: this.ve.edit.id,
                Name: this.ve.edit.name,
                RealName: this.ve.edit.real_name,
                Separator: this.ve.edit.separator,
                Encoding: this.ve.edit.encoding,
                ExtData: this.copyObj(this.ve.edit.ext_data),
            }
        },
        addVE: function () {
            this.ve.modal_info = this.ve.edit.real_name  + '(' + this.ve.edit.name + ')'
            this.$bvModal.show('confirm-add-ve')
        },
        appendVE: function () {
            this.ve.modal_info = this.ve.edit.real_name  + '(' + this.ve.edit.name + ')'
            this.$bvModal.show('confirm-add-ve')
        },
        addVEOK: function () {
            this.applyVE()
            this.callAddApi('VoiceEngineSpec', this.ve, `「${this.ve.edit.name}」`)
        },
        updateVE: function () {
            this.ve.modal_info = this.ve.edit.real_name  + '(' + this.ve.edit.name + ')'
            this.$bvModal.show('confirm-update-ve')
        },
        updateVEOK: function () {
            this.applyVE()
            this.callUpdateApi('VoiceEngineSpec', this.ve, `「${this.ve.edit.name}」`)
        },
        deleteVE: function () {
            this.ve.modal_info = this.ve.detail.body.RealName + '(' + this.ve.detail.body.Name + ')'
            this.$bvModal.show('confirm-delete-ve')
        },
        deleteVEOK: function () {
            console.log('delete ve ok')
            this.callDeleteApi('VoiceEngineSpec', this.ve, `「${this.ve.detail.body.Name}」`)
        },
        saveAll: function () {
            this.$bvModal.show('confirm-save-all')
        },
        saveAllOK: function () {
            axios.get('/api/v1/SaveAll/')
                .then(function (response) {
                    if(response.data.Message.Status == 0)
                    {
                        this.clearNotice()
                        this.mng.notice.has = true
                        this.mng.notice.message = 'YAMLファイルの保存に成功しました'
                    }
                    else
                    {
                        this.clearError()
                        this.mng.error.has = true
                        this.mng.error.message = `YAMLファイル保存エラー: ${response.data.Message.Message}`
                    }
                }.bind(this))
        },
        saveVH: function () {
            this.$bvModal.show('confirm-save-vh')
        },
        saveVHOK: function () {
            axios.get('/api/v1/SaveVH/')
                .then(function (response) {
                    if(response.data.Message.Status == 0)
                    {
                        this.clearNotice()
                        this.mng.notice.has = true
                        this.mng.notice.message = 'VegasHelper YAMLファイルの保存に成功しました'
                    }
                    else
                    {
                        this.clearError()
                        this.mng.error.has = true
                        this.mng.error.message = `VegasHelper YAMLファイル保存エラー: ${response.data.Message.Message}`
                    }
                }.bind(this))
        },
        revertAll: function () {
            this.$bvModal.show('confirm-revert-all')
        },
        revertAllOK: function () {
            axios.get('/api/v1/ResetAll/')
                .then(function (response) {
                    if(response.data.Message.Status == 0)
                    {
                        this.clearNotice()
                        this.setUp()
                        this.mng.notice.has = true
                        this.mng.notice.message = 'データの巻き戻しに成功しました'
                    }
                    else
                    {
                        this.clearError()
                        this.mng.error.has = true
                        this.mng.error.message = `巻き戻しエラー: ${response.data.Message.Message}`
                    }
                }.bind(this))
        },
        getColorType: function (color) {
            if(color[0] == '#'){ return 'rgb' }

            return 'named'
        },
        getColorRGB: function (color) {
            if(color[0] == '#'){ return color }

            return this.color.dict[color].Hex
        },
        setupColor: function(info, color){
            info.type = this.getColorType(color)
            info.name = color
            info.rgb = this.getColorRGB(color)
        },
        getColorFromInfo : function(info) {
            if(info.type === "named"){ return info.name }

            return info.rgb
        },
        selectChangedColor: function (color_info) {
            color_info.rgb = this.getColorRGB(color_info.name)
        },
        isColorIsNamed(color_info)
        {
            return color_info.type === 'named'
        },
        copyObj: function(org_obj) {
            var new_obj = {}
            Object.keys(org_obj).forEach(k => new_obj[k] = org_obj[k])
            return new_obj
        },
        filterObj: function (ext_data, key) {
            if(key.length === 0){ return ext_data }
            if(key in ext_data === false){ return ext_data }

            var new_obj = {}
            var keys = Object.keys(ext_data)
            Object.keys(ext_data).forEach(k => { if( k !== key) { new_obj[k] = ext_data[k] }})
            return new_obj
        },
        copyEditTextInfo: function (from, to) {
            to.text_color.type = from.text_color.type
            to.text_color.name = from.text_color.name
            to.text_color.rgb = from.text_color.rgb
            to.outline_color.type = from.outline_color.type
            to.outline_color.name = from.outline_color.name
            to.outline_color.rgb = from.outline_color.rgb
            to.outline_width = from.outline_width
        },
        callAddApi: function (spec_name, info, title) {
            var id = info.detail.body.Id
            var name = info.detail.body.Name
            axios.put(`/api/v1/${spec_name}/`, info.detail.body)
                .then(function (response) {
                    if(response.data.Message.Status == 0)
                    {
                        var new_id = response.data.NewId
                        info.names.push({Id: response.data.NewId, Name: name})

                        info.edit.enable = false
                        info.detail.id = -1
                        info.detail.body = null

                        this.clearNotice()
                        info.notice.has = true
                        info.notice.message = `${title}の追加に成功しました`

                    }
                    else
                    {
                        this.clearError()
                        info.error.has = true
                        info.error.message = `${title}の追加エラー: ${response.data.Message.Message}`
                    }
                }.bind(this))
        },
        callUpdateApi: function (spec_name, info, title) {
            var id = info.detail.body.Id
            var name = info.detail.body.Name
            axios.post(`/api/v1/${spec_name}/${id}/`, info.detail.body)
                .then(function (response) {
                    if(response.data.Message.Status == 0)
                    {
                        var index = info.names.findIndex(n => n.Id === id)
                        this.$set(info.names, index, {Id: id, Name: name})

                        info.edit.enable = false
                        info.detail.id = -1
                        info.detail.body = null

                        this.clearNotice()
                        info.notice.has = true
                        info.notice.message = `${title}の更新に成功しました`

                    }
                    else
                    {
                        this.clearError()
                        info.error.has = true
                        info.error.message = `${title}の更新エラー: ${response.data.Message.Message}`
                    }
                }.bind(this))
        },
        callDeleteApi: function (spec_name, info, title) {
            var id = info.detail.body.Id
            axios.delete(`/api/v1/${spec_name}/${id}/`)
                .then(function (response) {
                    if(response.data.Message.Status == 0)
                    {
                        var index = info.names.findIndex(n => n.Id === id)
                        info.names.splice(index, 1)

                        info.detail.id = -1
                        info.detail.body = null

                        this.clearNotice()
                        info.notice.has = true
                        info.notice.message = `${title}の削除に成功しました`
                    }
                    else
                    {
                        this.clearError()
                        info.error.has = true
                        info.error.message = `${title}の削除エラー: ${response.data.Message.Message}`
                    }
                }.bind(this))
        },
        showColorPage: function() {
            window.open('/colors.html')
        }
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
                    text_color: {
                        type: "",
                        name: "",
                        rgb: "",
                    },
                    outline_color: {
                        type: "",
                        name: "",
                        rgb: "",
                    },
                    outline_width: 0,
                },
                actor_name: {
                    text_color: {
                        type: "",
                        name: "",
                        rgb: "",
                    },
                    outline_color: {
                        type: "",
                        name: "",
                        rgb: "",
                    },
                    outline_width: 0,
                },
                ext_data: {},
                alias_text: "",
                ext_key: "",
                ext_value: "",
            },
            request_data: {},
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
                ext_key: "",
                ext_value: "",
            },
            request_data: {},
            modal_info: "",
            error: {
                has: false,
                message: "",
            },
            notice: {
                has: false,
                message: "",
            },
            encode_list: ['utf-8', 'shift_jis'],
            sep_list: [',', '＞'],
        },
        ve_san: {
            load_completed: false,
            edit: {},
            error: {
                has: false,
                message: "",
            },
            notice: {
                has: false,
                message: "",
            },
        },
        ve_none: {
            load_completed: false,
            edit: {},
            error: {
                has: false,
                message: "",
            },
            notice: {
                has: false,
                message: "",
            },
        },
        ve_sep: {
            load_completed: false,
            edit: {},
            error: {
                has: false,
                message: "",
            },
            notice: {
                has: false,
                message: "",
            },
        },
        color: {
            load_completed: false,
            specs: null,
            names: [],
            dict: {},
            detail: {
                id: 0,
                body: null,
            },
            error: {
                has: false,
                message: "",
            },
            notice: {
                has: false,
                message: "",
            },
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
