import React from 'react';
import './style/header.css';
import MultiFilter from './multi-filter';
import SearchFilter from './search-filter';

class FilterHeader extends React.Component {

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

        return (
            <div className="header">
                <SearchFilter key={0}
                    placeholder={"Contains..."}
                    onSearch={e => this.setFilter("contains", e)}
                />
                <MultiFilter key={1}
                    placeholder={"Filter by magic school..."}
                    options={schoolFilter}
                    onFilter={e => this.setFilter("schools", e)}
                />
                <MultiFilter key={2}
                    placeholder={"Filer by tag..."}
                    options={tagsFilter}
                    onFilter={e => this.setFilter("tags", e)}
                />
                <MultiFilter key={3}
                    placeholder={"By special..."}
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

        for(var obj of Object.keys(filterObj)) {
            for(var filter of filterObj[obj]) {
                filterQuery.push(obj+"="+filter);
            }
        }

        return filterQuery.length > 0
            ?   "?"+ filterQuery.join("&")
            :   "";
    }
}

export default FilterHeader;
