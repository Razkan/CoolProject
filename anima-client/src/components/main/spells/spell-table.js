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
            bookData: {},
            subpathData: {},

            bookFilter: {},
            subpathFilter: {},

            filterData: {},

            showFilterResult: false,

            showFilterSidebar: false
        };

        this.handleFilters = this.handleFilters.bind(this);

        this.fetchData = this.fetchData.bind(this);
        
        this.setupBooks = this.setupBooks.bind(this);
        this.setupSubpaths = this.setupSubpaths.bind(this);

        this.retryFetch = this.retryFetch.bind(this);

        this.getShowFilterResult = this.getShowFilterResult.bind(this);

        this.openFilterSidebar = this.openFilterSidebar.bind(this);
        this.closeFilterSidebar = this.closeFilterSidebar.bind(this);

        this.baseUrl = "http://localhost:9422/";
        this.bookUrl = this.baseUrl + "book/all";
        this.subpathUrl = this.baseUrl + "subpath/all";

        this.retry = null;
        this.showFilterResult = null;
    }

    componentDidMount() {
        this.fetchData(this.bookUrl, this.setupBooks, this.retryFetch)
            .then(() => this.fetchData(this.subpathUrl, this.setupSubpaths, this.retryFetch));
    }

    async fetchData(url, onSuccess, onFailure) {
        console.time("fetch");
        try {
            var response = await fetch(url);
            var body = await response.json();
            onSuccess(body);
        }
        catch (err) {
            onFailure(err, url, onSuccess, onFailure);
        }
        console.timeEnd("fetch");
    }

    retryFetch(error, url, onSuccess, onFailure) {
        console.log(error);
        console.log("Retrying in 1 minute");
        console.log(url);

        if (this.retry) {
            clearTimeout(this.retry);
        }

        this.retry = setTimeout(() => {
            this.fetchData(url, onSuccess, onFailure)
        }, 60000);
    }

    setupBooks(data) {

        var schools = {};
        var tags = {};

        // Get school
        for (var book of data) {

            schools[book.school] = book.school;

            // Get tags
            for (var spell of book.spells) {
                if (spell.tags) {
                    for (var tag of spell.tags) {
                        tags[tag] = tag;
                    }
                }
            }
        }

        const toFilter = obj => {
            return Object.values(obj).map(objValue => ({ value: objValue, label: objValue }));
        }

        var schoolsFilter = toFilter(schools);
        var tagsFilter = toFilter(tags);

        this.setState({
            bookData: data,
            bookFilter: { schools: schoolsFilter, tags: tagsFilter }
        });
    }

    setupSubpaths(data) {

        var schools = {};
        var tags = {};

        // Get school
        for (var book of data) {

            schools[book.school] = book.school;

            // Get tags
            for (var spell of book.spells) {
                if (spell.tags) {
                    for (var tag of spell.tags) {
                        tags[tag] = tag;
                    }
                }
            }
        }

        const toFilter = obj => {
            return Object.values(obj).map(objValue => ({ value: objValue, label: objValue }));
        }

        var schoolsFilter = toFilter(schools);
        var tagsFilter = toFilter(tags);

        this.setState({
            subpathData: data,
            subpathFilter: { schools: schoolsFilter, tags: tagsFilter }
        });
    }

    openFilterSidebar = () => this.setState({ showFilterSidebar: true });
    closeFilterSidebar = () => this.setState({ showFilterSidebar: false });

    handleFilters = query => {
        this.fetchData(this.bookUrl + query, data => this.setState({ bookData: data, showFilterResult: true }), this.retryFetch);
    };

    getSpellHeader() {
        return (<SpellHeader />);
    }

    copyObject(source, destination) {
        for (var key of Object.keys(source)) {
            destination[key] = {
                ...destination[key],
                ...source[key]
            };
        }
    }

    getSpellList() {
        var spells = [];

        var books = Object.values(this.state.bookData);
        books.push(...Object.values(this.state.subpathData));
        
        if (books) {
            for (var book of books) {
                if (book.spells) {
                    for (var spell of book.spells) {
                        spells.push({ school: book.school, data: spell });
                    }
                }
            }
        }

        spells = spells.sort((a, b) => {
            if (a.data.level > b.data.level) return 1;
            if (a.data.level < b.data.level) return -1;

            if (a.data.cost > b.data.cost) return 1;
            if (a.data.cost < b.data.cost) return -1;

            if (a.data.name > b.data.name) return 1;
            if (a.data.name < b.data.name) return -1;

            return 0;
        });

        return (<SpellList data={spells} />);
    }

    getShowFilterResult() {
        const countBooks = () => {
            return this.state.bookData.length + this.state.subpathData.length;
        };

        const countSpells = () => {
            var lengthArr = this.state.bookData.map(spellbook => spellbook.spells.length);
            lengthArr.push(...this.state.subpathData.map(spellbook => spellbook.spells.length));
            
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
                filterData={this.state.filterData}
                showFilterResult={this.getShowFilterResult()}
                openFilter={this.openFilterSidebar}
                closeFilter={this.closeFilterSidebar}
            />
        );
    }

    getFilter() {
        var filter = {
            schools: {},
            tags: {}
        };

        this.copyObject(this.state.bookFilter, filter);
        this.copyObject(this.state.subpathFilter, filter);

        return {
            schools: Object.values(filter.schools),
            tags: Object.values(filter.tags),
        };
    }

    getSidebar() {
        var classes = ["spell-table-sidebar"];

        if (!this.state.showFilterSidebar) {
            classes.push("spell-table-sidebar-hidden")
        }
        return (
            <div className={classes.join(" ")}>
                <FilterSidebar onFilterChanged={this.handleFilters}
                    filterData={this.getFilter()} />
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
