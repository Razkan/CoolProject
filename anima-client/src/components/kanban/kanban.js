import React from 'react';
import './style/kanban.css';
import CardCategory from './card-category';
import FilterHeader from './filter-header';

class Kanban extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            categoryData: {},
            filterData: {},

            showResult: false
        };

        this.handleFilters = this.handleFilters.bind(this);

        this.fetchData = this.fetchData.bind(this);
        this.setupData = this.setupData.bind(this);
        this.retryFetch = this.retryFetch.bind(this);
        
        this.getShowResult = this.getShowResult.bind(this);

        this.baseUrl = "http://localhost:9422/book/all";
        
        this.retry = null;
        this.showResult = null;
    }

    componentDidMount() {
        this.fetchData(this.baseUrl, this.setupData, this.retryFetch);
    }

    async fetchData(url, onSuccess, onFailure) {
        try {
            var response = await fetch(url);
            var body = await response.json();
            onSuccess(body);
        }
        catch (err) {
            onFailure(err, url, onSuccess, onFailure);
        }
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

    handleFilters = query => {
        this.fetchData(this.baseUrl + query, data => this.setState({ categoryData: data, showResult: true }), this.retryFetch);
    };

    getCategory() {
        var cardCategories = [];

        var books = Object.values(this.state.categoryData);
        if (books) {
            for (var book of books) {
                cardCategories.push(<CardCategory key={book.name} data={book} />);
            }
        }

        return cardCategories;
    }

    getHeader() {
        return (
            <FilterHeader onFilterChanged={this.handleFilters}
                filterData={this.state.filterData}
            />
        );
    }

    getShowResult() {

        const countBooks = () => {
            return this.state.categoryData.length;
        };

        const countSpells = () => {
            var lengthArr = this.state.categoryData.map(spellbook => spellbook.spells.length);
            if(lengthArr.length > 0) {
                return lengthArr.reduce((accumulator, current) => accumulator += current);
            }

            return 0;
        };

        if(this.state.showResult)
        {
            if (this.showResult) {
                clearTimeout(this.showResult);
            }
    
            this.showResult = setTimeout(() => {
                this.setState({showResult: false});
            }, 2000);

            return (
                <div className="kanban-show-filter-result">Found {countBooks()} books and {countSpells()} spells</div>
            );            
        }

        return (
            <div class="kanban-show-filter-result kanban-show-filter-result-hidden"></div>
        );
    }

    render() {
        return (
            <div className="kanban-container">
                {this.getHeader()}
                {this.getShowResult()}
                <div className="kanban">
                    {this.getCategory()}
                </div>
            </div>
        );
    }
}

export default Kanban;
