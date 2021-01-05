import React from 'react';
import './style/kanban.css';
import CardHeader from './card-list-header';
import CardList from './card-list';
import KanbanHeader from './kanban-header';
import FilterSidebar from './filter-sidebar';

class Kanban extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            categoryData: {},
            filterData: {},

            showFilterResult: false,

            showFilterSidebar: false
        };

        this.handleFilters = this.handleFilters.bind(this);

        this.fetchData = this.fetchData.bind(this);
        this.setupData = this.setupData.bind(this);
        this.retryFetch = this.retryFetch.bind(this);

        this.getShowFilterResult = this.getShowFilterResult.bind(this);

        this.openFilterSidebar = this.openFilterSidebar.bind(this);
        this.closeFilterSidebar = this.closeFilterSidebar.bind(this);

        this.baseUrl = "http://localhost:9422/book/all";

        this.retry = null;
        this.showFilterResult = null;
    }

    componentDidMount() {
        this.fetchData(this.baseUrl, this.setupData, this.retryFetch);
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

    setupData(data) {

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
            categoryData: data,
            filterData: { schools: schoolsFilter, tags: tagsFilter }
        });
    }

    openFilterSidebar = () => this.setState({ showFilterSidebar: true });
    closeFilterSidebar = () => this.setState({ showFilterSidebar: false });

    handleFilters = query => {
        this.fetchData(this.baseUrl + query, data => this.setState({ categoryData: data, showFilterResult: true }), this.retryFetch);
    };

    getCardHeader() {
        return (<CardHeader />);
    }

    getCardList() {
        var cards = [];

        var books = Object.values(this.state.categoryData);
        if (books) {
            for (var book of books) {
                if (book.spells) {
                    for (var spell of book.spells) {
                        cards.push({ school: book.school, data: spell });
                    }
                }
            }
        }
        
        cards = cards.sort((a, b) => {
            if(a.data.level > b.data.level) return 1;    
            if(a.data.level < b.data.level) return -1;
            
            if(a.data.cost > b.data.cost) return 1;    
            if(a.data.cost < b.data.cost) return -1;            
            
            if(a.data.name > b.data.name) return 1;    
            if(a.data.name < b.data.name) return -1;
        
            return 0;
        });
        return (<CardList data={cards} />);
    }

    getShowFilterResult() {
        const countBooks = () => {
            return this.state.categoryData.length;
        };

        const countSpells = () => {
            var lengthArr = this.state.categoryData.map(spellbook => spellbook.spells.length);
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
                <div className="kanban-show-filter-result">Found {countBooks()} books and {countSpells()} spells</div>
            );
        }

        return null;
    }

    getHeader() {
        return (
            <KanbanHeader onFilterChanged={this.handleFilters}
                filterData={this.state.filterData}
                showFilterResult={this.getShowFilterResult()}
                openFilter={this.openFilterSidebar}
                closeFilter={this.closeFilterSidebar}
            />
        );
    }

    getSidebar() {
        var classes = ["kanban-sidebar"];

        if (!this.state.showFilterSidebar) {
            classes.push("kanban-sidebar-hidden")
        }

        return (
            <div className={classes.join(" ")}>
                <FilterSidebar onFilterChanged={this.handleFilters}
                    filterData={this.state.filterData} />
            </div>
        );
    }

    render() {
        return (
            <div className="kanban-container">
                {this.getHeader()}
                <div className="kanban-content">
                    {this.getSidebar()}
                    <div className="kanban-board">
                        {this.getCardHeader()}
                        {this.getCardList()}
                    </div>
                </div>
            </div>
        );
    }
}

export default Kanban;
