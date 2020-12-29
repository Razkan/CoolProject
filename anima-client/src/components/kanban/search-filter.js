import React from 'react';
import './style/search-filter.css';

class SearchFilter extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            placeholder: props.placeholder,
            options: props.options,
            handleSearch: props.onSearch,
        };

        this.handleValue = this.handleValue.bind(this);
        this.handleKeyDown = this.handleKeyDown.bind(this);
    }

    handleKeyDown = e => {
        if (e.key === 'Enter') {
            e.target.blur();
        }
    }

    handleValue = event => {
        event.target.value
        ? this.state.handleSearch([event.target.value]) 
        :  this.state.handleSearch([]);
    };

    render() {
        return (
            <div className="search-filter-container">
                <input className="search-filter" 
                        type="text" 
                        name="name" 
                        placeholder={this.state.placeholder}
                        onChange={this.handleValue}
                        onKeyDown={this.handleKeyDown}
                        autoComplete="off"
                        />
            </div>
        );
    }
}

export default SearchFilter;
