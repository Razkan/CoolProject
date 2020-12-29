import React from 'react';
import Select from 'react-select';
import './style/multi-filter.css';

class MultiFilter extends React.Component {

    constructor(props) {
        super(props);

        this.handleValue = this.handleValue.bind(this);
    }

    handleValue = value => {
        value 
        ? this.props.onFilter(value.map(v => v.value)) 
        :  this.props.onFilter([]);
    };

    render() {
        return (
            <div className="multi-filter">
                <Select placeholder={this.props.placeholder}
                        isMulti={true}
                        options={this.props.options}
                        onChange={this.handleValue}
                />
            </div>
        );
    } 
}

export default MultiFilter;
