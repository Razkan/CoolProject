import React from 'react';
import './style/kanban-header.css';
import {
    faFilter,
    faSortAmountDown,
    faCaretDown
} from '@fortawesome/free-solid-svg-icons'
import ButtonMenu from './button-menu';

class KanbanHeader extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            showFilter: false,
            showSort: false
        }

        this.handleFilter = this.handleFilter.bind(this);
        this.handleSort = this.handleSort.bind(this);
    }

    handleFilter = () => {
        var showFilter = !this.state.showFilter;
        if (showFilter) {
            this.props.openFilter();
            this.setState({ showFilter: showFilter, showSort: false });
        }
        else {
            this.props.closeFilter();
            this.setState({ showFilter: showFilter });
        }
    };

    handleSort = () => {
        var showSort = !this.state.showSort;
        if (showSort) {
            this.setState({ showSort: showSort, showFilter: false });
        }
        else {
            this.setState({ showSort: showSort });
        }
    }

    render() {
        return (
            <div className="kanban-header">
                <ButtonMenu shared={this.state.menuState}
                    icon={faFilter}
                    text="Filter"
                    active={this.state.showFilter}
                    onClick={this.handleFilter}>
                </ButtonMenu>
                <ButtonMenu shared={this.state.menuState}
                    icon={faSortAmountDown}
                    text="Sort"
                    active={this.state.showSort}
                    onClick={this.handleSort}
                >
                </ButtonMenu>
                {this.props.showFilterResult}
            </div>
        );
    }
}

export default KanbanHeader;
