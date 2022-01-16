import React from 'react';
import './style/search-filter.css';

class SearchFilter extends React.Component {

    constructor(props) {
        super(props);

        this.handleValue = this.handleValue.bind(this);
        this.handleKeyDown = this.handleKeyDown.bind(this);

        this.inputTimeout = null;
    }

    handleKeyDown = e => {
        if (e.key === 'Enter') {
            e.target.blur();
        }
    }

    handleValue = event => {        
        if(this.inputTimeout) {
            clearTimeout(this.inputTimeout);
        }

        this.inputTimeout = setTimeout(() => {
            event.target.value
            ? this.props.onSearch([event.target.value]) 
            :  this.props.onSearch([]);
        }, 250);
    };

    render() {
        return (
            <div className="search-filter-container">

                <div className="search-filter-header">
                    {this.props.title}
                </div>
                
                <input className="search-filter-input" 
                        type="text" 
                        name="name" 
                        placeholder="..."
                        onChange={this.handleValue}
                        onKeyDown={this.handleKeyDown}
                        autoComplete="off"
                        />
            </div>
        );
    }
}

export default SearchFilter;
