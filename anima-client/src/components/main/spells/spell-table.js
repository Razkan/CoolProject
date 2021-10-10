import React from 'react';
import './style/spell-table.css';
import SpellHeader from './spell-list-header';
import SpellList from './spell-list';
import SpellTableHeader from './spell-table-header';
import FilterSidebar from './filter-sidebar';

class SpellTable extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            books: {},
            filters: {
                schools: [],
                tags: [],
                specials: []
            },

            coreBookFilter: {},
            arcanaBookFilter: {},

            showFilterResult: false,
            showFilterSidebar: false
        };

        this.handleFilters = this.handleFilters.bind(this);

        this.fetch = this.fetch.bind(this);
        this.retryFetch = this.retryFetch.bind(this);

        this.getShowFilterResult = this.getShowFilterResult.bind(this);

        this.openFilterSidebar = this.openFilterSidebar.bind(this);
        this.closeFilterSidebar = this.closeFilterSidebar.bind(this);

        this.baseUrl = "";
        this.coreUrl = this.baseUrl + "/core/all";
        this.arcanaUrl = this.baseUrl + "/arcana/all";

        this.retry = null;
        this.showFilterResult = null;
    }

    openFilterSidebar = () => this.setState({ showFilterSidebar: true });
    closeFilterSidebar = () => this.setState({ showFilterSidebar: false });

    handleFilters = query => this.getData(query);

    componentDidMount() {
        this.getData();
    }

    createFilter() {
        var schools = {};
        var tags = {};
        var specials = {};

        for (const school of this.state.filters.schools) {
            schools[school.value] = school.value;
        }

        for (const tag of this.state.filters.tags) {
            tags[tag.value] = tag.value;
        }

        for (const special of this.state.filters.specials) {
            specials[special.value] = special.value;
        }

        for (const bookArr of Object.values(this.state.books)) {
            for (var book of bookArr) {
                schools[book.school] = book.school;

                // Get tags
                for (var spell of book.spells) {
                    specials[spell.maintenanceDuration] = spell.maintenanceDuration;

                    if (spell.tags) {
                        for (var tag of spell.tags) {
                            tags[tag] = tag;
                        }
                    }
                }
            }
        }

        const toFilter = obj => {
            return Object.values(obj).map(objValue => ({ value: objValue, label: objValue }));
        }

        this.setState({
            filters: {
                schools: toFilter(schools),
                tags: toFilter(tags),
                specials: toFilter(specials),
            }
        });
    }

    async getData(query) {
        query = query || "";

        const getCore = data => this.setState({
            books: { core: data, arcana: this.state.books.arcana || [] },
        });

        const getArcana = data => this.setState({
            books: { arcana: data, core: this.state.books.core || [] }
        });

        var core = null;
        var arcana = null;
        
        await this.fetch(this.coreUrl + query, result => core = result, this.retryFetch);
        await this.fetch(this.arcanaUrl + query, result => arcana = result, this.retryFetch);

        if (core) {
            getCore(core);
        }
        if(arcana) {
            getArcana(arcana);
        }

        this.createFilter();
    }

    async fetch(url, onSuccess, onFailure) {
        console.time(url);
        try {
            var response = await fetch(url);
            var body = await response.json();
            onSuccess(body);
        }
        catch (err) {
            onFailure(err, url, onSuccess, onFailure);
        }
        console.timeEnd(url);
    }

    retryFetch(error, url, onSuccess, onFailure) {
        console.log(error);
        console.log("Retrying in 1 minute");
        console.log(url);

        if (this.retry) {
            clearTimeout(this.retry);
        }

        this.retry = setTimeout(() => {
            this.fetch(url, onSuccess, onFailure)
        }, 60000);
    }

    getSpellHeader() {
        return (<SpellHeader />);
    }

    getSpellList() {
        return (<SpellList books={this.state.books} />);
    }

    getShowFilterResult() {
        const countBooks = () => {
            var length = 0;
            for (var bookArr of Object.values(this.state.books)) {
                length += bookArr.length;
            }
            return length;
        };

        const countSpells = () => {
            var lengthArr = [];

            for (var bookArr of Object.values(this.state.books)) {
                lengthArr.push(...bookArr.map(spellbook => spellbook.spells.length));
            }

            if (lengthArr.length > 0) {
                return lengthArr.reduce((accumulator, current) => accumulator += current);
            }

            return 0;
        };

        if (this.state.showFilterResult) {
            if (this.showFilterResult) {
                clearTimeout(this.showFilterResult);
            }

            this.showFilterResult = setTimeout(() => {
                this.setState({ showFilterResult: false });
            }, 2000);

            return (
                <div className="spell-table-show-filter-result">Found {countBooks()} books and {countSpells()} spells</div>
            );
        }

        return null;
    }

    getHeader() {
        return (
            <SpellTableHeader onFilterChanged={this.handleFilters}
                showFilterResult={this.getShowFilterResult()}
                openFilter={this.openFilterSidebar}
                closeFilter={this.closeFilterSidebar}
            />
        );
    }

    getSidebar() {
        var classes = ["spell-table-sidebar"];

        if (!this.state.showFilterSidebar) {
            classes.push("spell-table-sidebar-hidden")
        }
        return (
            <div className={classes.join(" ")}>
                <FilterSidebar onFilterChanged={this.handleFilters}
                    filterData={this.state.filters} />
            </div>
        );
    }

    render() {
        return (
            <div className="spell-table-container">
                {this.getHeader()}
                <div className="spell-table-content">
                    {this.getSidebar()}
                    <div className="spell-table-board">
                        {this.getSpellHeader()}
                        {this.getSpellList()}
                    </div>
                </div>
            </div>
        );
    }
}

export default SpellTable;
