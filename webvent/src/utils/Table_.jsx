import React,{ useState, useRef } from 'react';
import PropTypes from 'prop-types';
import { Table, Input, Button, Space } from 'antd';
import Highlighter from 'react-highlight-words';
import { SearchOutlined } from '@ant-design/icons';


function is_numeric(value) {
	return !isNaN(parseFloat(value)) && isFinite(value);
}

function  Table_({columns, data , rowKey}){

    const [searchText, setSearchText] = useState('');
    const [searchedColumn, setSearchedColumn] = useState('');
    const searchInput = React.createRef(); 

    const getColumnSearchProps = dataIndex => ({
        filterDropdown: ({ setSelectedKeys, selectedKeys, confirm, clearFilters }) => (
          <div style={{ padding: 8 }}>
            <Input 
              ref={ searchInput }
              placeholder={`Search ${dataIndex}`}
              value={selectedKeys[0]}
              onChange={e => setSelectedKeys(e.target.value ? [e.target.value] : [])}
              onPressEnter={() => handleSearch(selectedKeys, confirm, dataIndex)}
              style={{ width: 188, marginBottom: 8, display: 'block' }}
            />
            <Space>
              <Button
                type="primary"
                onClick={() => handleSearch(selectedKeys, confirm, dataIndex)}
                icon={<SearchOutlined />}
                size="small"
                style={{ width: 90 }}
              >
                Buscar
              </Button>
              <Button onClick={() => handleReset(clearFilters)} size="small" style={{ width: 90 }}>
                Limpiar
              </Button>
            </Space>
          </div>
        ),
        filterIcon: filtered => <SearchOutlined style={{ color: filtered ? '#1890ff' : undefined }} />,
        onFilter: (value, record) =>  record[dataIndex] ? record[dataIndex].toString().toLowerCase().includes(value.toLowerCase()) : '',
        onFilterDropdownVisibleChange: visible => {
          if (visible) {
              setTimeout(() => searchInput.current.select()); 
          }
        },
        sorter: (a, b) =>  
        (
          is_numeric(a[dataIndex]) ?  a[dataIndex] - b[dataIndex] 
          : a[dataIndex].localeCompare(b[dataIndex])
        ),
        sortDirections: ['descend', 'ascend'],

        render: text =>
        searchedColumn === dataIndex ? (
            <Highlighter
              highlightStyle={{ backgroundColor: '#ffc069', padding: 0 }}
              searchWords={[searchText]}
              autoEscape
              textToHighlight={text ? text.toString() : ''}
            />
          ) : (
            text
          ),
      });
    
     const handleSearch = (selectedKeys, confirm, dataIndex) => {
        confirm();
        setSearchText(selectedKeys[0])
        setSearchedColumn(dataIndex)
      };
    
      const handleReset = clearFilters => {
        clearFilters();
        setSearchText('')
      };

    const columnsTable = columns
    .filter(element => element.hidden !== true)
    .map((col) => { 
        if(!col.render){
            return {
              title: col.title.charAt(0).toUpperCase() + col.title.slice(1),
              dataIndex:  col.dataIndex,
              key: col.dataIndex,
              width: col.width,
              hidden: col.hiden ?? true,
              ...getColumnSearchProps(col.dataIndex)
          }
        }
        else{
              return {
                title: col.title.charAt(0).toUpperCase() + col.title.slice(1),
                dataIndex:  col.dataIndex,
                key: col.dataIndex,
                width: col.width,
                hidden: col.hiden ?? true,
                render: col.render ?? null
            }
        }
    });

    return   <Table     
      columns={columnsTable ? columnsTable : null} 
      dataSource={data ? data : null} 
      bordered={true}
      size='small'    
      pagination={{
        showQuickJumper :true,
        showSizeChanger: true,
        pageSizeOptions: ['10', '20', '30', '40' ,'50'],
      }}
      size={'default'} 
      rowKey={ rowKey }
    />;    
}


Table_.propTypes = {
  columns: PropTypes.arrayOf(PropTypes.shape({
        dataIndex: PropTypes.string.isRequired,
        title: PropTypes.string.isRequired,
        width: PropTypes.string.isRequired,
        hidden: PropTypes.bool,
        render: PropTypes.func,
    })
  ).isRequired,
  data: PropTypes.any.isRequired,
  rowKey: PropTypes.string,
};

export default Table_;