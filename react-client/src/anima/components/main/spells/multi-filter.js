import React from 'react';
import Select from 'react-select';
import './style/multi-filter.css';

class MultiFilter extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            menuOpen: false
        }

        this.onMenuOpen = this.onMenuOpen.bind(this);
        this.onMenuClose = this.onMenuClose.bind(this);
        this.handleValue = this.handleValue.bind(this);
    }

    onMenuOpen = () => this.setState({ menuOpen: true });
    onMenuClose = () => this.setState({ menuOpen: false });

    handleValue = value => {
        value
            ? this.props.onFilter(value.map(v => v.value))
            : this.props.onFilter([]);
    };

    render() {
        const selectStyles = {
            menuList: (provided, state) => ({
                ...provided,
                maxHeight: "250px"
            }),
            control: (provided, state) => ({
                ...provided,
                flexWrap: "nowrap"
            }),
            valueContainer: (provided, state) => ({
                ...provided,
                flexWrap: "nowrap"
            })
        };

        return (
            <div className="multi-filter-container">

                <div className="multi-filter-header">
                    {this.props.title}
                </div>

                <div className="multi-filter">
                    <Select styles={selectStyles}
                        isMulti={true}
                        options={this.props.options}
                        onChange={this.handleValue}
                        onMenuOpen={this.onMenuOpen}
                        onMenuClose={this.onMenuClose}
                    />
                </div>
            </div>
        );
    }
}

export default MultiFilter;
