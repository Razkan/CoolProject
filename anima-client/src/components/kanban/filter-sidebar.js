import React from 'react';
import './style/filter-sidebar.css';
import MultiFilter from './multi-filter';
import SearchFilter from './search-filter';
import HighlightFilter from './highlight-filter';

class FilterSidebar extends React.Component {

    constructor(props) {
        super(props);

        this.filters = {
            contains: "",
            schools: [],
            tags: [],
            special: []
        };

        this.setFilter = this.setFilter.bind(this);
        this.filterAsQuery = this.filterAsQuery.bind(this);
    }

    render() {
        var schoolFilter = this.props.filterData.schools || [];
        var tagsFilter = this.props.filterData.tags || [];
        var key = 0;
        return (
            <div className="filter-sidebar">

                <HighlightFilter key={key++}
                    title="Highlight word"
                />

                <SearchFilter key={key++}
                    title="Filter by Spells"
                    onSearch={e => this.setFilter("contains", e)}
                />
                <MultiFilter key={key++}
                    title="Magic School"
                    options={schoolFilter}
                    onFilter={e => this.setFilter("schools", e)}
                />
                <MultiFilter key={key++}
                    title="Tag"
                    options={tagsFilter}
                    onFilter={e => this.setFilter("tags", e)}
                />
                <MultiFilter key={key++}
                    title="Special"
                    options={[]}
                    onFilter={e => this.setFilter("specials", e)}
                />
            </div>
        );
    }

    setFilter(key, value) {
        this.filters[key] = value;
        this.props.onFilterChanged(this.filterAsQuery(this.filters));
    }

    filterAsQuery(filterObj) {

        var filterQuery = [];

        for (var obj of Object.keys(filterObj)) {
            for (var filter of filterObj[obj]) {
                filterQuery.push(obj + "=" + filter);
            }
        }

        return filterQuery.length > 0
            ? "?" + filterQuery.join("&")
            : "";
    }
}

export default FilterSidebar;
